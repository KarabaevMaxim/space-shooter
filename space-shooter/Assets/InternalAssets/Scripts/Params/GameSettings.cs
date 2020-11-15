using System;
using Karabaev.Gameplay.Bullets;
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
    
    public GameSettings(int bulletsPoolsCapacity, Bullet[] bullets)
    {
      _bulletsPoolsCapacity = bulletsPoolsCapacity;
      _bullets = bullets;
    }
  }
}