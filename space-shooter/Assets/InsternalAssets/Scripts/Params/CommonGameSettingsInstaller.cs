using UnityEngine;
using Zenject;

namespace Karabaev.Params
{
  [CreateAssetMenu(fileName = "CommonParams", menuName = "Karabaev/CommonParams", order = 0)]
  public class CommonGameSettingsInstaller : ScriptableObjectInstaller<CommonGameSettingsInstaller>
  {
    [SerializeField]
    private GameSettings _gameSettings = default;
    
    public override void InstallBindings()
    {
      Container.BindInstance(_gameSettings).IfNotBound();
    }
  }
}