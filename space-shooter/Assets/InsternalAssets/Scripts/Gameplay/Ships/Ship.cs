using UnityEngine;

namespace Karabaev.Gameplay.Ships
{
  public class Ship : MainComponent
  {
    [SerializeField, HideInInspector]
    private IBulletsSpawner[] _guns;

    protected override void OnValidate()
    {
      base.OnValidate();

      var guns = GetComponentsInChildren<IBulletsSpawner>();

      if (guns != null)
        _guns = guns;
    }
  }
}