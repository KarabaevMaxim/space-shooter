using System.Collections.Generic;
using System.Threading.Tasks;
using Karabaev.Storage.Entities;

namespace Karabaev.Storage
{
  public interface IStoragesAggregator
  {
    Task SaveLevelAsync(Level entity);
    
    Task<IReadOnlyList<Level>> ReadAllLevelsAsync();
    
    IReadOnlyList<Level> ReadAllLevels();

    void InitializeDefaultData();
  }
}