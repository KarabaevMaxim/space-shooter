using System;

namespace Karabaev.Storage.Entities
{
  public class Level : IEntity
  {
    public Guid Id { get; set; }
    
    public int Number { get; set; }
    
    public string Name { get; set; }
    
    public string Opened { get; set; }
    
    public string Completed { get; set; }
  }
}