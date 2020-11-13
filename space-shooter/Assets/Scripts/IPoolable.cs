namespace Karabaev
{
  public interface IPoolable
  {
    int Id { get; set; }
    
    void OnSpawned();

    void OnDespawned();
  }
}