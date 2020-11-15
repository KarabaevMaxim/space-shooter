using System;
using System.Linq;
using System.Reflection;

namespace Karabaev.Infrastructure
{
  public static class ReflectionHelper
  {
    public static bool IsImplementedType<T>(Type type)
    {
      if (typeof(T) == type)
        return true;
      
      var implemented = type.GetTypeInfo().ImplementedInterfaces;
      return implemented.Any(imp => imp == typeof(T));
    }

    public static void SetPropertyWithoutSetter(object obj, string propName, object newValue)
    {
      var type = obj.GetType();
      var field = GetPrivateField(type, $"<{propName}>k__BackingField"); // ищем поле у автосвойства

      var startsWithLowerPropName = propName.First().ToString().ToLower() + propName.Substring(1);
      
      if (field == null)
        field = GetPrivateField(type, startsWithLowerPropName);

      if (field == null)
        field = GetPrivateField(type, $"_{startsWithLowerPropName}");
      
      field.SetValue(obj, newValue);
    }

    public static FieldInfo GetPrivateField(Type type, string fieldName)
    {
      return type.GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
    }
    
    public static bool DefinedAttributeOnType<TAttr>(Type type, bool inherit) where TAttr : Attribute
    {
      return type.GetTypeInfo().IsDefined(typeof(TAttr), inherit);
    }
    
    public static bool DefinedAttributeOnType<TType, TAttr>(bool inherit) where TAttr : Attribute
    {
      return typeof(TType).GetTypeInfo().IsDefined(typeof(TAttr), inherit);
    }
    
    public static TAttr GetDefinedAttributeFromType<TAttr>(Type type, bool inherit) where TAttr : Attribute
    {
      return type.GetCustomAttribute<TAttr>(inherit);
    }
    
    public static TAttr GetDefinedAttributeFromType<TType, TAttr>(bool inherit) where TAttr : Attribute
    {
      return typeof(TType).GetCustomAttribute<TAttr>(inherit);
    }
  }
}