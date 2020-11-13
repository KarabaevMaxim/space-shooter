using System;
using Karabaev.Bullets;
using UnityEngine;

namespace Karabaev.Params
{
  [Serializable]
  public struct GameSettings
  {
    [Header("Настройки снарядов")]
    [SerializeField]
    private int _bulletsPoolsCapacity;

    [SerializeField]
    private Bullet[] _bullets;
    
    public int BulletsPoolsCapacity => _bulletsPoolsCapacity;

    public Bullet[] Bullets => _bullets;
  }
}