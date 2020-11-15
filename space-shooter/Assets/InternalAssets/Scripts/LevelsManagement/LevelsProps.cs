using System;
using System.Collections.Generic;
using Karabaev.Infrastructure;
using UnityEngine;

namespace Karabaev.LevelsManagement
{
  [Serializable]
  public struct LevelsProps
  {
    [SerializeField]
    private LevelDescription[] _levels;

    public IReadOnlyList<LevelDescription> Levels => _levels;

    public void OnValidate()
    {
      var levels = new LevelDescription[Levels.Count];

      for (var i = 0; i < Levels.Count; i++)
        levels[i].InitializeNumber(i);
    }
    
    public LevelsProps(LevelDescription[] levels)
    {
      _levels = levels;
    }
  }
}