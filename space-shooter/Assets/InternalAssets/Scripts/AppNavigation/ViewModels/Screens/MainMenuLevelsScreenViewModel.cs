using System.Collections.Generic;
using Karabaev.LevelsManagement;
using Karabaev.UI.MainMenu;

namespace Karabaev.AppNavigation.ViewModels.Screens
{
  /// <summary>
  /// Вьюмодель экрана уровней главного меню.
  /// </summary>
  public class MainMenuLevelsScreenViewModel : ScreenViewModel
  {
    private ILevelsService _levelsService;
    
    private IReadOnlyList<Level> _levels;
    private LevelsScreen _levelsScreen;
    
    public override void OnCreated(object context)
    {
      base.OnCreated(context);

      _levelsScreen = Root.GetComponent<LevelsScreen>();
      _levelsService = SceneContainer.Resolve<ILevelsService>();
      _levels = _levelsService.Levels;
      _levelsScreen.LevelsBtnClickAction = ParentViewModel.Pop;
    }

    public override void OnActivated(object context)
    {
      base.OnActivated(context);

      // if (context is Level[] levels)
      // {
      //   _levels = levels;
      //   return;
      // }
      //
      // throw new ArgumentOutOfRangeException(nameof(context), 
      //   new ArgumentOutOfRangeMessage(GetType(), nameof(OnActivated), typeof(Level[]), context.GetType()));
    }
  }
}