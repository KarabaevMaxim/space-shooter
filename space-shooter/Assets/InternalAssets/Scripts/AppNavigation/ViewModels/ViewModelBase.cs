namespace Karabaev.AppNavigation.ViewModels
{
  /// <summary>
  /// Базовый класс вьюмодели, нужен для фабрики вьюмоделей, так как она не работает с интерфейсами и абстрактными типами.
  /// </summary>
  public class ViewModelBase : IViewModel
  {
    public virtual void OnCreated(object context)
    {
    }

    public virtual void OnActivated(object context)
    {
    }

    public virtual void OnDeactivated()
    {
    }
  }
}