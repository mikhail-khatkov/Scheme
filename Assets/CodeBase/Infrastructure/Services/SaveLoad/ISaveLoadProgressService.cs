using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
  public interface ISaveLoadProgressService : IService
  {
    void SaveProgress();
    PlayerProgress LoadProgress();
  }
}