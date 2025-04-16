using System;
using UnityEngine.Serialization;

namespace CodeBase.Data
{
    [Serializable]
    public class GameData
    {
        public int CurrentLevel;
        public int CompletedLevel;
        public int MaxLevel;

        public void ExtendLevel()
        {
            if (CurrentLevel + 1 > MaxLevel) 
                return;

            CurrentLevel++;
            CompletedLevel = CompletedLevel+1 < CurrentLevel ? CompletedLevel++ : CompletedLevel;
        }
    }
}