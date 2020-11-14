using Karabaev.Storage;
using Karabaev.Storage.Entities;
using Zenject;

namespace Karabaev.Ioc
{
  public class AppInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      UnityEngine.Application.targetFrameRate = 60;
      
      Container.Bind<IStorage<Level>>().To<JsonStorage<Level>>().AsSingle();
    }
  }
}