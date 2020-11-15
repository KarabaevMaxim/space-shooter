using System.Collections.Generic;
using System.Threading.Tasks;
using Karabaev.Storage.Entities;

namespace Karabaev.Storage
{
  public class StoragesAggregator : IStoragesAggregator
  {
    private readonly IStorage<Level> _levelsStorage;

    public Task SaveLevelAsync(Level entity) => _levelsStorage.SaveAsync(entity);

    public Task<IReadOnlyList<Level>> ReadAllLevelsAsync() => _levelsStorage.ReadAllAsync();

    public IReadOnlyList<Level> ReadAllLevels() => _levelsStorage.ReadAll();

    public void InitializeDefaultData() => _levelsStorage.InitializeDefaultData();

    public StoragesAggregator(IStorage<Level> levelsStorage) => _levelsStorage = levelsStorage;
  }
}