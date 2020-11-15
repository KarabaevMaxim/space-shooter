using System;

namespace Karabaev.Storage.Entities
{
  /// <summary>
  /// Сущность уровня для хранения в хранилище.
  /// </summary>
  public class Level : IEntity
  {
    public Guid Id { get; set; }
    
    public int Number { get; set; }
    
    public string Name { get; set; }
    
    public bool Opened { get; set; }
    
    public bool Completed { get; set; }
  }
}