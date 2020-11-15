using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karabaev.LevelsManagement
{
  public interface ILevelsService
  {
    IReadOnlyList<Level> Levels { get; }

    Task InitializeLevelsAsync();

    Task CompleteLevelAsync(Guid levelId);

    Task OpenLevelAsync(Guid levelId);
  }
}