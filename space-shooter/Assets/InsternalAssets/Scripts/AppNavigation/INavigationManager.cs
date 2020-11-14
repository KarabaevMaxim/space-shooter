using Karabaev.AppNavigation.ViewModels;
using UnityEngine;

namespace Karabaev.AppNavigation
{
  public interface INavigationManager
  {
    void OpenScene<TViewModel>(object context) where TViewModel : SceneViewModel;

    AsyncOperation OpenSceneAsync<TViewModel>(object context) where TViewModel : SceneViewModel;
  }
}