using System;
using Zenject;

namespace Karabaev.AppNavigation.ViewModels.Management
{
  public class ViewModelFactory : PlaceholderFactory<Type, ViewModelBase>, IViewModelFactory
  {
    private readonly DiContainer _container;

    public override ViewModelBase Create(Type param)
    {
      var result = (ViewModelBase)_container.Instantiate(param);
      return result;
    }
    
    public ViewModelFactory(DiContainer container)
    {
      _container = container;
    }
  }
}