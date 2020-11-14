using System.Collections.Generic;
using UnityEngine;

namespace Karabaev.AppNavigation.Props
{
  public interface INavigationProps
  {
    IReadOnlyList<SceneViewModelPair> Scenes { get; }

    GameObject LoadingScreen { get; }

    void Validate();
  }
}