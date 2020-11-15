using System;
using System.Collections.Generic;

namespace Karabaev.Infrastructure
{
  // ReSharper disable once InconsistentNaming
  public static class IEnumerableExtensions
  {
    /// <summary>
    /// Выполняет действие action для каждого элемента коллекции.
    /// </summary>
    /// <param name="collection">Коллекция для перебора.</param>
    /// <param name="action">Действие.</param>
    /// <typeparam name="T">Любой тип.</typeparam>
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
      foreach (var item in collection)
        action.Invoke(item);
    }
  }
}