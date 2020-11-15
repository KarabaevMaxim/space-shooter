using System;
using System.Reflection;

namespace Karabaev.Infrastructure
{
  public readonly struct ArgumentOutOfRangeMessage
  {
    private readonly Type _siteType;
    private readonly string _methodName;
    private readonly Type _expectedParamType;
    private readonly Type _currentParamType;
    
    public override string ToString()
    {
      return $"{_siteType.Name}.{_methodName}: передан контекст неожиданного типа {_currentParamType.Name}. Ожидается тип {_expectedParamType}";
    }

    public ArgumentOutOfRangeMessage(Type siteType, string methodName, Type expectedParamType, Type currentParamType)
    {
      _siteType = siteType;
      _methodName = methodName;
      _expectedParamType = expectedParamType;
      _currentParamType = currentParamType;
    }
    
    public static implicit operator string(ArgumentOutOfRangeMessage instance)
    {
      return instance.ToString();
    }
  }
}