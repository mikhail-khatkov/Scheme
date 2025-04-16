using System;

namespace CodeBase.Data
{
  [Serializable]
  public class PlayerProgress
  {
    public GameData GameData;

    public PlayerProgress()
    {
      GameData = new GameData();
    }
  }
}