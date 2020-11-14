using System;
using UnityEngine;

namespace Karabaev.Bullets.Props
{
  [Serializable]
  public struct BulletsProps : IBulletsProps
  {
    [SerializeField]
    private float _moveSpeed;

    public float MoveSpeed => _moveSpeed;
  }
}