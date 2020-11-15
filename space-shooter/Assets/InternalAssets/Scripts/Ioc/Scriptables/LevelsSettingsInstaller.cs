using Karabaev.LevelsManagement;
using UnityEngine;
using Zenject;

namespace Karabaev.Ioc.Scriptables
{
  [CreateAssetMenu(fileName = "LevelsSettings", menuName = "Karabaev/LevelsSettings", order = 0)]
  public class LevelsSettingsInstaller : ScriptableObjectInstaller<LevelsSettingsInstaller>
  {
    [SerializeField]
    private LevelsProps _levelsProps = default;
    
    public override void InstallBindings()
    {
      Container.BindInstance(_levelsProps).AsSingle();
    }

    private void OnValidate()
    {
      _levelsProps.OnValidate();
    }
  }
}