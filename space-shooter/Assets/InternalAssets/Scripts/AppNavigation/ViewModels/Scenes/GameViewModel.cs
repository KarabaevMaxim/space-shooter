using Karabaev.AppNavigation.Props;
using Karabaev.AppNavigation.ViewModels.Management;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels.Scenes
{
  /// <summary>
  /// Вьюмодель игровой сцены.
  /// </summary>
  public class GameViewModel : SceneViewModel
  {
    public GameViewModel() : this(null, null, null, null)
    {
    }
    
    [Inject]
    public GameViewModel(INavigationProps navProps, 
      INavigationManager navigationManager, 
      IViewModelFactory factory, 
      EmptyMonoBehaviour monoBeh) : base(navProps, navigationManager, factory, monoBeh)
    {
    }
  }
}