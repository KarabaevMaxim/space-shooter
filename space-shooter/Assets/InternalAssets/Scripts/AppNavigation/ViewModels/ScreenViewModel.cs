using UnityEngine;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels
{
  public class ScreenViewModel : ViewModelBase
  {
    public SceneViewModel ParentViewModel { get; set; }
    
    public GameObject Root { get; set; }
    
    public DiContainer SceneContainer { get; set; }
  }
}