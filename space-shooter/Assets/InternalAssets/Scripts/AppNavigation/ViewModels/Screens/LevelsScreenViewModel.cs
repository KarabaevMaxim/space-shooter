using System;
using Karabaev.Infrastructure;
using Karabaev.LevelsManagement;

namespace Karabaev.AppNavigation.ViewModels.Screens
{
  public class LevelsScreenViewModel : ScreenViewModel
  {
    private Level[] _levels;
    
    public override void OnActivated(object context)
    {
      base.OnActivated(context);

      if (context is Level[] levels)
      {
        _levels = levels;
        return;
      }
      
      throw new ArgumentOutOfRangeException(nameof(context), 
        new ArgumentOutOfRangeMessage(GetType(), nameof(OnActivated), typeof(Level[]), context.GetType()));
    }
  }
}