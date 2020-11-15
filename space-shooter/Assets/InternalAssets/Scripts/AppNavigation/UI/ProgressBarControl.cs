using UnityEngine;
using UnityEngine.UI;

namespace Karabaev.AppNavigation.UI
{
  public class ProgressBarControl : MonoBehaviour, IProgressBarControl
  {
    [SerializeField, HideInInspector]
    private Image _progressImage;

    private float _progress;
    
    public float Progress
    {
      get => _progress;
      set
      {
        _progress = value;
        Mathf.Clamp(_progress, 0.0f, 1.0f);
        _progressImage.fillAmount = value;
      }
    }

    private void OnValidate()
    {
      if (!_progressImage)
        _progressImage = GetComponentInChildren<Image>();
    }
  }
}