using UnityEngine;

namespace Karabaev.AppNavigation.ViewModels
{
  public class ScreenViewModel : ViewModelBase
  {
    public SceneViewModel ParentViewModel { get; set; }
    
    public GameObject Root { get; set; }
  }
}