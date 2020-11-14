namespace Karabaev
{
  public interface IPoolable
  {
    /// <summary>
    /// Идентификатор в пуле.
    /// </summary>
    int Id { get; set; }
    
    void OnSpawned();

    void OnDespawned();
  }
}