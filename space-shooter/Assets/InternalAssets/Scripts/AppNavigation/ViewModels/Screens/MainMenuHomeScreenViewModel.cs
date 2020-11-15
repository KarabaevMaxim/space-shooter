using Karabaev.UI.MainMenu;
using UnityEngine;

namespace Karabaev.AppNavigation.ViewModels.Screens
{
  /// <summary>
  /// Вьюмодель главного экрана главного меню.
  /// </summary>
  public class MainMenuHomeScreenViewModel : ScreenViewModel
  {
    private HomeScreen _homeScreen;
    
    public override void OnCreated(object context)
    {
      base.OnCreated(context);

      _homeScreen = Root.GetComponent<HomeScreen>();
      _homeScreen.LevelsBtnClickAction = ToLevelsScreen;
    }

    public override void OnActivated(object context)
    {
      base.OnActivated(context);
    }

    private void ToLevelsScreen()
    {
      ParentViewModel.Push<MainMenuLevelsScreenViewModel>(null, true);
    }
  }
}