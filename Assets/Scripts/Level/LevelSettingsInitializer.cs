using LevelData;
using Menu;
using UnityEngine;

namespace Level
{
    public class LevelSettingsInitializer : MonoBehaviour
    {
        private void Awake()
        {
            LevelLoader.LevelLoaded += InitializeLevelSettings;
        }

        private void InitializeLevelSettings(LevelSettings settings)
        {
            LevelLoader.LevelLoaded -= InitializeLevelSettings;

        }
    }
}