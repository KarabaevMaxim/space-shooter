using System.Collections.Generic;
using System.Linq;
using Karabaev.Infrastructure;
using UnityEngine;
using Zenject;

namespace Karabaev.Gameplay
{
  [RequireComponent(typeof(GameObjectContext))]
  [RequireComponent(typeof(ZenjectBinding))]
  public class MainComponent : MonoBehaviour, IBindableComponent
  {
    protected virtual void OnValidate()
    {
      SetZenjectBinding();
      var another = GetComponents<MainComponent>();

      if(another.Length > 1)
        Debug.LogError($"На объекте {name} больше одного главного компонента '{string.Join(", ", another.Select(a => a.GetType().Name))}'");
    }

    private void SetZenjectBinding()
    {
      var binding = GetComponent<ZenjectBinding>();
      ReflectionHelper.SetPropertyWithoutSetter(binding, nameof(binding.BindType), ZenjectBinding.BindTypes.AllInterfacesAndSelf);
      var toBind = GetComponents<IBindableComponent>().Cast<Component>().ToList();
      AddCustomComponents(toBind);
      
      ReflectionHelper.SetPropertyWithoutSetter(binding, nameof(binding.Components), toBind.ToArray());
    }

    private void AddCustomComponents(ICollection<Component> list)
    {
      var animator = GetComponent(typeof(Animator));
      
      if (animator)
        list.Add(animator);
      
      // ReSharper disable once LocalVariableHidesMember
      var rigidbody = GetComponent(typeof(Rigidbody));
      
      if (rigidbody)
        list.Add(rigidbody);
    }

  }
}