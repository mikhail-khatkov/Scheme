using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
  public class SaveLoadProgressService : ISaveLoadProgressService
  {
    private const string ProgressKey = "Progress";
    
    private readonly IPersistentProgressService _progressService;

    public SaveLoadProgressService(IPersistentProgressService progressService)
    {
      _progressService = progressService;
    }

    public void SaveProgress()
    {
      PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
    }

    public PlayerProgress LoadProgress()
    {
      return PlayerPrefs.GetString(ProgressKey)?
        .ToDeserialized<PlayerProgress>();
    }
  }
}