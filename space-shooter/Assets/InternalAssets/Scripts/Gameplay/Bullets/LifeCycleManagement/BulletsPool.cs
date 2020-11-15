using System.Collections.Generic;
using Karabaev.Params;
using UnityEngine;

namespace Karabaev.Gameplay.Bullets.LifeCycleManagement
{
  public class BulletsPool
  {
    private readonly Dictionary<int, Queue<Bullet>> _pools;

    public Bullet Spawn(Bullet prefab)
    {
      var id = prefab.GetInstanceID();
      var bullet = _pools[id].Dequeue();
      bullet.gameObject.SetActive(true);
      bullet.OnSpawned();
      return bullet;
    }

    public void Despawn(Bullet bullet)
    {
      bullet.gameObject.SetActive(false);
     _pools[bullet.Id].Enqueue(bullet);
     bullet.OnDespawned();
    }
    
    public BulletsPool(BulletsFactory factory, GameSettings settings)
    {
      _pools = new Dictionary<int, Queue<Bullet>>(settings.Bullets.Length);
      var parent = new GameObject("Bullets");

      foreach (var bullet in settings.Bullets)
      {
        var prefab = (Object) bullet;
        var key = prefab.GetInstanceID();
        _pools[key] = new Queue<Bullet>(settings.BulletsPoolsCapacity);

        for (var i = 0; i < settings.Bullets.Length; i++)
        {
          var instance = factory.Create(prefab);
          instance.Id = key;
          instance.gameObject.SetActive(false);
          instance.transform.parent = parent.transform;
          _pools[key].Enqueue(instance);
        }
      }
    }
  }
}