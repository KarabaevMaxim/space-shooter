using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Karabaev.AppNavigation.Props
{
  [Serializable]
  public struct NavigationProps : INavigationProps
  {
    [SerializeField]
    private SceneViewModelPair[] _scenes;

    [SerializeField]
    private GameObject _loadingScreen;
    
    public IReadOnlyList<SceneViewModelPair> Scenes => _scenes;

    public GameObject LoadingScreen => _loadingScreen;

    public void Validate()
    {
      {
        var grouped = Scenes.GroupBy(s => s.ViewModel?.GetType());
        var result = grouped.Where(g => g.Count() > 1);

        foreach (var group in result)
        {
          if (group.Key == null)
            continue;
          
          Debug.LogError(
            $"В конфигурации навигации {nameof(NavigationProps)} вьюмодель {group.Key.Name} привязана к нескольким сценам.");
        }
      }
    }
    
    public NavigationProps(SceneViewModelPair[] scenes, GameObject loadingScreen)
    {
      _scenes = scenes;
      _loadingScreen = loadingScreen;
    }
  }
}