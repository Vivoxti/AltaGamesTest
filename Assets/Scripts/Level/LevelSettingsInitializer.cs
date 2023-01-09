using LevelData;
using Menu;
using UnityEngine;

namespace Level
{
    public class LevelSettingsInitializer : MonoBehaviour
    {
        private LevelSettings _settings;

        public float MinCharacterSize => _settings.MinCharacterSize/100f;

        public float GetExplosionAreaRadius(float shellCharge)
        {
           return _settings.ShellExplosionRadiusSettings.GetExplosionRadius(shellCharge);
        } 
        private void Awake()
        {
            LevelLoader.LevelLoaded += InitializeLevelSettings;
        }

        private void InitializeLevelSettings(LevelSettings settings)
        {
            _settings = settings;
            LevelLoader.LevelLoaded -= InitializeLevelSettings;
        }
    }
}