using System;
using UnityEngine;

namespace Level
{
    public class LevelStage : MonoBehaviour
    {
        private Stage _currentStage;
        
        public Stage CurrentStage => _currentStage;

        public event Action<Stage> StageChanged;

        public void SetStage(Stage newStage)
        {
            _currentStage = newStage;
            StageChanged?.Invoke(_currentStage);
        }
        public enum Stage
        {
            Shooting,
            VictoriousAdvance,
            WinResult,
            Defeat,
            DefeatResult,
        }
    }
}