using Karabaev.Gameplay.Bullets;
using Karabaev.Gameplay.Bullets.LifeCycleManagement;
using Karabaev.Gameplay.Bullets.Props;
using UnityEngine;
using Zenject;

namespace Karabaev.Gameplay.Ships
{
  public class BulletsSpawner : MonoBehaviour, IBulletsSpawner, IBindableComponent
  {
    [SerializeField]
    private Bullet _bulletPrefab = default;

    [SerializeField]
    private Transform _spawnPoint = default;

    [SerializeReference, SR]
    // ReSharper disable once FieldCanBeMadeReadOnly.Local
    private IBulletsProps _bulletsProps = default;
    
    private BulletsPool _pool;

    public Bullet Spawn()
    {
      var bullet = _pool.Spawn(_bulletPrefab);
      bullet.Initialize(_bulletsProps);
      return bullet;
    }

    [Inject]
    private void Initialize(BulletsPool pool)
    {
      _pool = pool;
    }
  }
}