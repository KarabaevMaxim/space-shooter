using Karabaev.Bullets.Props;
using UnityEngine;
using Zenject;

namespace Karabaev.Bullets
{
  public class Bullet : MainComponent, IPoolable
  {
    private IBulletBehaviour _behaviour;

    public void Initialize(IBulletsProps param)
    {
      _behaviour.Initialize(param);
    }

    public int Id { get; set; }

    public void OnSpawned()
    {
      transform.rotation = Quaternion.identity;
      _behaviour.StartBehaviour();
    }

    public void OnDespawned()
    {
      _behaviour.EndBehaviour();
    }
    
    [Inject]
    private void Initialize(IBulletBehaviour behaviour)
    {
      _behaviour = behaviour;
    }
  }
}