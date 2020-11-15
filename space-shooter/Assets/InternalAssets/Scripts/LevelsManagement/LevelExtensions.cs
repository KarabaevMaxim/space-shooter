using System;

namespace Karabaev.LevelsManagement
{
  public static class LevelExtensions
  {
    public static Level FromEntity(this Storage.Entities.Level entity) =>
      new Level
      {
        Id = entity.Id,
        Number = entity.Number,
        Name = entity.Name,
        Completed = entity.Completed,
        Opened = entity.Opened
      };
    
    public static Level FromDescription(this LevelDescription description) =>
      new Level
      {
        Id = Guid.NewGuid(),
        Number = description.Number,
        Name = description.Name,
        Completed = description.Completed,
        Opened = description.Opened
      };
    
    public static Storage.Entities.Level ToEntity(this Level level) =>
      new Storage.Entities.Level
      {
        Id = level.Id,
        Number = level.Number,
        Name = level.Name,
        Completed = level.Completed,
        Opened = level.Opened
      };
  }
}