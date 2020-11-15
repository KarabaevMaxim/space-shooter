namespace Karabaev.AppNavigation.ViewModels
{
  public interface IViewModel
  {
    void OnCreated(object context);

    void OnActivated(object context);

    void OnDeactivated();
  }
}