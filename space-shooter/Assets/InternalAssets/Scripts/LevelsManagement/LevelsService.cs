using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Karabaev.Storage;

namespace Karabaev.LevelsManagement
{
  public class LevelsService : ILevelsService
  {
    private readonly LevelsProps _props;
    private readonly IStoragesAggregator _storagesAggregator;

    public IReadOnlyList<Level> Levels { get; private set; }

    public async Task InitializeLevelsAsync()
    {
      // сначала читаем из хранилища
      var levels = await _storagesAggregator.ReadAllLevelsAsync();

      if (levels.Count != 0)
      {
        Levels = levels.Select(l => l.FromEntity()).ToList();
        return;
      }
      
      // если в хранилище не нашли информацию об уровнях, тогда читаем из настроек
      Levels = _props.Levels.Select(l => l.FromDescription()).ToList();
    }
    
    public async Task CompleteLevelAsync(Guid levelId)
    {
      var level = Levels.First(l => l.Id == levelId);
      level.Completed = true;
      await _storagesAggregator.SaveLevelAsync(level.ToEntity());
    }
    
    public async Task OpenLevelAsync(Guid levelId)
    {
      var level = Levels.First(l => l.Id == levelId);
      level.Opened = true;
      await _storagesAggregator.SaveLevelAsync(level.ToEntity());
    }
    
    public LevelsService(LevelsProps props, IStoragesAggregator storagesAggregator)
    {
      _props = props;
      _storagesAggregator = storagesAggregator;
    }
  }
}