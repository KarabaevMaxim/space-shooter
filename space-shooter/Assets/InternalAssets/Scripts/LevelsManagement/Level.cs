using System;

namespace Karabaev.LevelsManagement
{
  /// <summary>
  /// Уровень.
  /// </summary>
  public class Level
  {
    public Guid Id { get; set; }
    
    public int Number { get; set; }
    
    public string Name { get; set; }
    
    public bool Opened { get; set; }
    
    public bool Completed { get; set; }
  }
}