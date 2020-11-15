using Karabaev.LevelsManagement;
using Zenject;

namespace Karabaev.Ioc.Mono
{
  public class MainMenuInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<ILevelsService>().To<LevelsService>().AsSingle();
    }
  }
}