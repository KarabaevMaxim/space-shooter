using UnityEngine;

namespace Karabaev.Infrastructure
{
  public static class RectTransformExtensions
  {
    public static void SetLeft(this RectTransform rt, float value)
    {
      rt.offsetMin = new Vector2(value, rt.offsetMin.y);
    }
 
    public static void SetRight(this RectTransform rt, float value)
    {
      rt.offsetMax = new Vector2(-value, rt.offsetMax.y);
    }
 
    public static void SetTop(this RectTransform rt, float value)
    {
      rt.offsetMax = new Vector2(rt.offsetMax.x, -value);
    }
 
    public static void SetBottom(this RectTransform rt, float value)
    {
      rt.offsetMin = new Vector2(rt.offsetMin.x, value);
    }
    
    public static void SetSidesOffsets(this RectTransform rt, float left, float right, float top, float bottom)
    {
      SetLeft(rt, left);
      SetRight(rt, right);
      SetTop(rt, top);
      SetBottom(rt, bottom);
    }
  }
}