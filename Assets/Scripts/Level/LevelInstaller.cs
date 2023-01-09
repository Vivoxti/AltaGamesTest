using Level.CharacterShoot;
using UnityEngine;
using Zenject;

namespace Level
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelSettingsInitializer levelSettingsInitializer;
        [SerializeField] private ShootSystem shootSystem;
        [SerializeField] private Character character;
        [SerializeField] private Door door;

        public override void InstallBindings()
        {
            Container.Bind<LevelSettingsInitializer>().FromInstance(levelSettingsInitializer);
            Container.Bind<ShootSystem>().FromInstance(shootSystem);
            Container.Bind<Character>().FromInstance(character);
            Container.Bind<Door>().FromInstance(door);
        }
    }
}