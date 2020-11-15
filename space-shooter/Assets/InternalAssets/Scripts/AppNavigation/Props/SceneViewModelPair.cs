using System;
using System.Collections.Generic;
using Karabaev.AppNavigation.ViewModels;
using UnityEngine;

namespace Karabaev.AppNavigation.Props
{
  /// <summary>
  /// Привязка вьюмодели к сцене.
  /// </summary>
  [Serializable]
  public struct SceneViewModelPair
  {
    [SerializeField]
    private string _sceneName;

    [SerializeReference, SR]
    private SceneViewModel _viewModel;

    [SerializeField]
    private List<ScreenViewModelPair> _screens;
    
    public string SceneName => _sceneName;

    public SceneViewModel ViewModel => _viewModel;

    public IReadOnlyList<ScreenViewModelPair> Screens => _screens;

    public SceneViewModelPair(string sceneName, SceneViewModel viewModel, List<ScreenViewModelPair> screens)
    {
      _sceneName = sceneName;
      _viewModel = viewModel;
      _screens = screens;
    }
  }
}