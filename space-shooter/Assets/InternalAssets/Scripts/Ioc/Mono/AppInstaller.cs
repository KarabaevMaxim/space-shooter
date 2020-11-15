using System;
using Karabaev.AppNavigation;
using Karabaev.AppNavigation.ViewModels;
using Karabaev.AppNavigation.ViewModels.Management;
using Karabaev.Storage;
using Zenject;
using Level = Karabaev.Storage.Entities.Level;

namespace Karabaev.Ioc.Mono
{
  public class AppInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      UnityEngine.Application.targetFrameRate = 60;
      
      Container.Bind<IStorage<Level>>().To<JsonStorage<Level>>().AsSingle();
      Container.Bind<IStoragesAggregator>().To<StoragesAggregator>().AsSingle();
      Container.Bind<EmptyMonoBehaviour>().FromNewComponentOn(gameObject).AsSingle();
      Container.Bind<INavigationManager>().To<NavigationManager>().AsSingle().NonLazy();
      Container.BindFactoryCustomInterface<Type, ViewModelBase, ViewModelFactory, IViewModelFactory>().AsSingle();
    }
  }
}