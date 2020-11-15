using Karabaev.AppNavigation.Props;
using Karabaev.AppNavigation.ViewModels.Management;
using Karabaev.AppNavigation.ViewModels.Screens;
using Karabaev.LevelsManagement;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels.Scenes
{
  /// <summary>
  /// Вьюмодель главного меню.
  /// </summary>
  public class MainMenuViewModel : SceneViewModel
  {
    #region Зависимости

    private readonly ILevelsService _levelsService;

    #endregion

    #region ЖЦ вьюмодели

    public override async void OnActivated(object context)
    {
      base.OnActivated(context);
      Push<MainMenuHomeScreenViewModel>(null, false);
      await _levelsService.InitializeLevelsAsync();
    }

    #endregion

    #region Конструкторы

    public MainMenuViewModel() : this(null, null, null, null, null)
    {
    }

    [Inject]
    public MainMenuViewModel(INavigationProps navProps, 
      INavigationManager navigationManager, 
      IViewModelFactory factory, 
      EmptyMonoBehaviour monoBeh,
      ILevelsService levelsService) : base(navProps, navigationManager, factory, monoBeh)
    {
      _levelsService = levelsService;
    }

    #endregion
  }
}