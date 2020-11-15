using Karabaev.AppNavigation.Props;
using Karabaev.AppNavigation.ViewModels.Management;
using Karabaev.Storage;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels.Scenes
{
  /// <summary>
  /// Вьюмодель сплэшскрина.
  /// </summary>
  public class SplashScreenViewModel : SceneViewModel
  {
    private readonly IStoragesAggregator _storagesAggregator;

    public override async void OnActivated(object context)
    {
      base.OnActivated(context);
      Push<Screens.SplashScreenViewModel>(null, false);
      await _storagesAggregator.ReadAllLevelsAsync();
      OpenSceneAsync<MainMenuViewModel>(null);
    }

    public SplashScreenViewModel() : this(null, null, null, null, null)
    {
    }

    [Inject]
    public SplashScreenViewModel(INavigationProps navProps, 
      INavigationManager navigationManager,
      IViewModelFactory factory, 
      EmptyMonoBehaviour monoBeh,
      IStoragesAggregator storagesAggregator) : base(navProps, navigationManager, factory, monoBeh)
    {
      _storagesAggregator = storagesAggregator;
    }
  }
}