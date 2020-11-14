using Karabaev.AppNavigation.Props;
using UnityEngine;
using Zenject;

namespace Karabaev.Ioc
{
  /// <summary>
  /// Инсталлер настроек навигации по приложения.
  /// </summary>
  [CreateAssetMenu(fileName = "AppNavigationSettings", menuName = "Karabaev/AppNavigationSettings", order = 1)]
  public class AppNavigationSettingsInstaller : ScriptableObjectInstaller<AppNavigationSettingsInstaller>
  {
    [SerializeReference, SR]
    private INavigationProps _navigationProps = default;
    
    public override void InstallBindings()
    {
      Container.BindInstance(_navigationProps).IfNotBound();
    }
  }
}