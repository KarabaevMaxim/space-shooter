using System;
using System.Linq;
using Karabaev.AppNavigation.Props;
using Karabaev.AppNavigation.ViewModels;
using Karabaev.AppNavigation.ViewModels.Management;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Karabaev.AppNavigation
{
  public class NavigationManager : INavigationManager
  {
    private INavigationProps _props;
    private IViewModelFactory _factory;

    private SceneViewModel _loadingScene;
    private SceneViewModel _currentScene;

    public void OpenScene<TViewModel>(object context) where TViewModel : SceneViewModel
    {
      var scene = _props.Scenes.First(s => s.ViewModel is TViewModel);
      _loadingScene = CreateViewModel<TViewModel>(context);
      SceneManager.LoadScene(scene.SceneName, LoadSceneMode.Single);
    }

    public AsyncOperation OpenSceneAsync<TViewModel>(object context) where TViewModel : SceneViewModel
    {
      var scene = _props.Scenes.First(s => s.ViewModel is TViewModel);
      _loadingScene = CreateViewModel<TViewModel>(context);
      var operation = SceneManager.LoadSceneAsync(scene.SceneName, LoadSceneMode.Single);
      operation.allowSceneActivation = true;

      return operation;
    }

    private TViewModel CreateViewModel<TViewModel>(object context) where TViewModel : SceneViewModel
    {
      var scene = _factory.Create(typeof(TViewModel));
      scene.OnCreated(context);

      return (TViewModel) scene;
    }

    private SceneViewModel CreateViewModel(Type vmType, object context)
    {
      var scene = _factory.Create(vmType);
      scene.OnCreated(context);

      return (SceneViewModel) scene;
    }

    [Inject]
    private void Initialize(INavigationProps props, IViewModelFactory factory)
    {
      _props = props;
      _factory = factory;
    
      var sceneName = SceneManager.GetActiveScene().name;
    
      var vmType = _props.Scenes.First(s => 
        s.SceneName.Equals(sceneName, StringComparison.OrdinalIgnoreCase)).ViewModel.GetType();
    
      _loadingScene = CreateViewModel(vmType, null); // активируем первую сцену
    
      SceneManager.sceneLoaded += (scene, mode) =>
      {
        _currentScene = _loadingScene;
        _loadingScene = null;
        _currentScene.OnActivated(null);
      };
    
      SceneManager.sceneUnloaded += scene => _currentScene.OnDeactivated();
    }
  }
}