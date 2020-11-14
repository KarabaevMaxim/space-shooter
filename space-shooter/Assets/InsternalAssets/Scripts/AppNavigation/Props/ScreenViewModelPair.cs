using System;
using Karabaev.AppNavigation.ViewModels;
using UnityEngine;

namespace Karabaev.AppNavigation.Props
{
  /// <summary>
  /// Привязка вьюмодели к экрану.
  /// </summary>
  [Serializable]
  public struct ScreenViewModelPair
  {
    [SerializeField]
    private Transform _rootView;

    [SerializeReference, SR]
    private ScreenViewModel _viewModel;

    public Transform RootView => _rootView;

    public ScreenViewModel ViewModel => _viewModel;

    public ScreenViewModelPair(Transform rootView, ScreenViewModel viewModel)
    {
      _rootView = rootView;
      _viewModel = viewModel;
    }
  }
}