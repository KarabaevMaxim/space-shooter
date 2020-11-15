using Karabaev.Gameplay.Bullets.Props;

namespace Karabaev.Gameplay.Bullets
{
  public interface IBulletBehaviour
  {
    void Initialize(IBulletsProps props);

    void StartBehaviour();
    
    void EndBehaviour();
  }
}