using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Karabaev.AppNavigation.Props;
using Karabaev.AppNavigation.UI;
using Karabaev.AppNavigation.ViewModels.Management;
using Karabaev.Infrastructure;
using UnityEngine;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels
{
  public class SceneViewModel : ViewModelBase
  {
    #region Зависимости

    private readonly INavigationProps _navProps;
    private readonly INavigationManager _navigationManager;
    private readonly IViewModelFactory _factory;
    protected EmptyMonoBehaviour EmptyMonoBeh { get; }

    #endregion

    #region Поля и свойства

    private IReadOnlyList<ScreenViewModel> _screens;
    private Stack<ScreenViewModel> _backStack;
    private IProgressBarControl _loadingProgressBar;
    private GameObject _loadingScreen;

    protected DiContainer SceneContainer { get; private set; }

    #endregion

    #region Методы жц вьюмоделей

    public override void OnActivated(object context)
    {
      base.OnActivated(context);
      
      // подразумевается, что на каждой сцене будет SceneContext
      var diContext = Object.FindObjectOfType<SceneContext>();
      SceneContainer = diContext.Container;
      CreateUI();
    }

    public override void OnDeactivated()
    {
      base.OnDeactivated();

      _screens.ForEach(s => s.OnDeactivated());
    }

    #endregion

    #region Методы навигации

    public void OpenSceneAsync<TViewModel>(object context) where TViewModel : SceneViewModel
    {
      OpenLoadingScreen();
      EmptyMonoBeh.StartCoroutine(OpenSceneInternalAsync<TViewModel>(context));
    }

    public void OpenScene<TViewModel>(object context) where TViewModel : SceneViewModel
    {
      OpenLoadingScreen();
      _navigationManager.OpenScene<TViewModel>(context);
    }

    /// <summary>
    /// Открывает новый экран.
    /// </summary>
    public void Push<TViewModel>(object context, bool hidePrev) where TViewModel : ScreenViewModel
    {
      var screen = _screens.First(s => s is TViewModel);
      
      if (hidePrev && _backStack.Count != 0)
        _backStack.Peek().Root.SetActive(false);
      
      _backStack.Push(screen);
      screen.Root.SetActive(true);
      screen.Root.transform.SetAsLastSibling();
      screen.OnActivated(context);
    }
    
    /// <summary>
    /// Закрывает текущий экран и открывает предыдущий.
    /// </summary>
    public void Pop()
    {
      if (_backStack.Count == 0)
        return;

      var screen = _backStack.Pop();
      screen.Root.SetActive(false);
      screen.OnDeactivated();
      
      if (_backStack.Count == 0)
        return;
      
      _backStack.Peek().Root.SetActive(true);
    }

    private IEnumerator OpenSceneInternalAsync<TViewModel>(object context) where TViewModel : SceneViewModel
    {
      var operation = _navigationManager.OpenSceneAsync<TViewModel>(context);

      while (!operation.isDone)
      {
        // тут можно запускать корутину для более плавного отображения прогресса
        _loadingProgressBar.Progress = operation.progress;
        yield return null;
      }
    }

    #endregion

    #region Остальные методы

    private void CreateUI()
    {
      var canvas = Object.FindObjectOfType<Canvas>();
      var screens = new List<ScreenViewModel>();

      _navProps.Scenes.First(s => s.ViewModel.GetType() == GetType()).Screens.ForEach(s =>
      {
        var viewModel = (ScreenViewModel) _factory.Create(s.ViewModel.GetType());
        var transform = (RectTransform) Object.Instantiate(s.RootView, canvas.transform);
        transform.SetSidesOffsets(0, 0, 0, 0);
        viewModel.Root = transform.gameObject;
        viewModel.ParentViewModel = this;
        viewModel.SceneContainer = SceneContainer;
        viewModel.Root.SetActive(false);
        viewModel.OnCreated(null);
        screens.Add(viewModel);
      });

      InitializeLoadingScreen(canvas);

      _screens = screens;
      _backStack = new Stack<ScreenViewModel>();
    }

    private void OpenLoadingScreen()
    {
      Pop();
      _loadingScreen.SetActive(true);
      _loadingScreen.transform.SetAsFirstSibling();
    }

    private void InitializeLoadingScreen(Canvas canvas)
    {
      _loadingScreen = (GameObject) Object.Instantiate(_navProps.LoadingScreen, canvas.transform);
      var transform = (RectTransform)_loadingScreen.transform;
      transform.SetSidesOffsets(0, 0, 0,0);
      _loadingProgressBar = _loadingScreen.GetComponentInChildren<IProgressBarControl>();
      _loadingScreen.SetActive(false);
    }
    
    #endregion

    #region Конструкторы
    
    public SceneViewModel(INavigationProps navProps,
      INavigationManager navigationManager,
      IViewModelFactory factory,
      EmptyMonoBehaviour monoBeh)
    {
      _navProps = navProps;
      _navigationManager = navigationManager;
      _factory = factory;
      EmptyMonoBeh = monoBeh;
    }
    
    #endregion
  }
}