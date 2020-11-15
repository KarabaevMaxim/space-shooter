using System;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels.Management
{
  public interface IViewModelFactory : IFactory<Type, ViewModelBase>
  {
  }
}