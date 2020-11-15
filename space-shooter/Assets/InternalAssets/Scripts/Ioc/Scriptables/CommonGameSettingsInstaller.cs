using Karabaev.Params;
using UnityEngine;
using Zenject;

namespace Karabaev.Ioc.Scriptables
{
  [CreateAssetMenu(fileName = "CommonGameSettings", menuName = "Karabaev/CommonGameSettings", order = 0)]
  public class CommonGameSettingsInstaller : ScriptableObjectInstaller<CommonGameSettingsInstaller>
  {
    [SerializeField]
    private GameSettings _gameSettings = default;
    
    public override void InstallBindings()
    {
      Container.BindInstance(_gameSettings).AsSingle();
    }
  }
}