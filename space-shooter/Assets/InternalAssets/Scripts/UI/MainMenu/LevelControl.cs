using UnityEngine;
using UnityEngine.UI;

namespace Karabaev.UI.MainMenu
{
  /// <summary>
  /// Контрол уровня на карте уровней в главном меню.
  /// </summary>
  public class LevelControl : MonoBehaviour
  {
    [SerializeField, HideInInspector]
    private Button _btn;

    private void OnValidate()
    {
      if (!_btn)
        _btn = GetComponent<Button>();
    }
  }
}