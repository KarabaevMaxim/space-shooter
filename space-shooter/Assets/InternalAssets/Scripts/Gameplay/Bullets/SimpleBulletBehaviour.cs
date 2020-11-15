using System.Collections;
using Karabaev.Gameplay.Bullets.Props;
using UnityEngine;
using Zenject;

namespace Karabaev.Gameplay.Bullets
{
  /// <summary>
  /// Поведение снаряда, летящего по прямой до столкновения.
  /// </summary>
  public class SimpleBulletBehaviour : MonoBehaviour, IBulletBehaviour, IBindableComponent
  {
    private float _speed;
    private Coroutine _coroutine;
    private Rigidbody _rigidbody;
    private WaitForFixedUpdate _awaiter;
    
    public void Initialize(IBulletsProps props)
    {
      _speed = props.MoveSpeed;
    }

    public void StartBehaviour()
    {
      _coroutine = StartCoroutine(Loop());
    }

    public void EndBehaviour()
    {
      if (_coroutine != null)
      {
        StopCoroutine(_coroutine);
        _coroutine = null;
      }
    }

    private IEnumerator Loop()
    {
      while (true)
      {
        _rigidbody.velocity += transform.forward * (_speed * Time.fixedDeltaTime);
        yield return _awaiter;
      }
      // ReSharper disable once FunctionNeverReturns
    }

    [Inject]
    // ReSharper disable once ParameterHidesMember
    private void Initialize(Rigidbody rigidbody)
    {
      _rigidbody = rigidbody;
      _awaiter = new WaitForFixedUpdate();
    }
  }
}