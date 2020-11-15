using System;
using UnityEngine;

namespace Karabaev.LevelsManagement
{
  /// <summary>
  /// Описание уровня.
  /// </summary>
  [Serializable]
  public struct LevelDescription
  {
    [SerializeField, HideInInspector]
    private int _number;

    [SerializeField]
    private string _name;

    [SerializeField]
    private bool _opened;

    [SerializeField]
    private bool _completed;

    public int Number => _number;

    public string Name => _name;

    public bool Opened => _opened;

    public bool Completed => _completed;

    public void InitializeNumber(int number) => _number = number;

    public LevelDescription(int number, string name, bool opened, bool completed)
    {
      _number = number;
      _name = name;
      _opened = opened;
      _completed = completed;
    }
  }
}