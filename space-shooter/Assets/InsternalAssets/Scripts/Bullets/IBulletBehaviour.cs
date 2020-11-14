using Karabaev.Bullets.Props;

namespace Karabaev.Bullets
{
  public interface IBulletBehaviour
  {
    void Initialize(IBulletsProps props);

    void StartBehaviour();
    
    void EndBehaviour();
  }
}