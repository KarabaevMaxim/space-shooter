using System;

namespace Karabaev.Storage.Entities
{
  public interface IEntity
  {
    Guid Id { get; set; }
  }
}