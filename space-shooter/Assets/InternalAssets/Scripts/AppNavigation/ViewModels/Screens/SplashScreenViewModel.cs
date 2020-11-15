using Karabaev.AppNavigation.ViewModels.Scenes;

namespace Karabaev.AppNavigation.ViewModels.Screens
{
  public class SplashScreenViewModel : ScreenViewModel
  {
    public override void OnActivated(object context)
    {
      base.OnActivated(context);
      
      //ParentViewModel.OpenSceneAsync<MainMenuViewModel>(null);
    }
  }
}