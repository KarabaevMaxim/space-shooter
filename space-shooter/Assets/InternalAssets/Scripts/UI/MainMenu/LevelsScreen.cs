using System;
using UnityEngine;
using UnityEngine.UI;

namespace Karabaev.UI.MainMenu
{
  public class LevelsScreen : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private LevelsControl _levelsControl;

    [SerializeField]
    private Button _backBtn;
    
    public Action LevelsBtnClickAction
    {
      set
      {
        _backBtn.onClick.RemoveAllListeners();
        _backBtn.onClick.AddListener(() => value?.Invoke());
      }
    }
    
    private void OnValidate()
    {
      if (!_levelsControl)
        _levelsControl = GetComponentInChildren<LevelsControl>();
    }
  }
}