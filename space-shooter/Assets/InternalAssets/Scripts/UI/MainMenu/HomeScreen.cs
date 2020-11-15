using System;
using UnityEngine;
using UnityEngine.UI;

namespace Karabaev.UI.MainMenu
{
  public class HomeScreen : MonoBehaviour
  {
    [SerializeField]
    private Button _levelsBtn;

    public Action LevelsBtnClickAction
    {
      set
      {
        _levelsBtn.onClick.RemoveAllListeners();
        _levelsBtn.onClick.AddListener(() => value?.Invoke());
      }
    }
  }
}