using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Level.CharacterShoot
{
    public class Shell : MonoBehaviour
    {
        [SerializeField] private Transform shellModel;
        [SerializeField] private AnimationCurve launchSpeedByCharge;
        [SerializeField] private ParticleSystem shellParticles;
        private LevelSettingsInitializer _levelSettingsInitializer;
        private Door _door;
        
        private float _shellCharge;
        
        [Inject]
        private void Inject(LevelSettingsInitializer levelSettingsInitializer,Door door)
        {
            _levelSettingsInitializer = levelSettingsInitializer;
            _door = door;
        }
        public void Launch()
        {
            var launchDuration = launchSpeedByCharge.Evaluate(_shellCharge);
            transform.DOLocalMoveZ(_door.FinalPoint.z,launchDuration).SetEase(Ease.OutCubic).OnComplete(Explode);
            transform.DOLocalMoveY(2f, launchDuration *0.3f).SetEase(Ease.OutCubic).OnComplete(
                () => { transform.DOLocalMoveY(0f, launchDuration *0.7f).SetEase(Ease.InCubic); }
            );
        }

        public void Boost(float boostValue)
        {
            _shellCharge += boostValue;
            shellModel.localScale = Vector3.one * _shellCharge;
        }
        
        private void Explode()
        {
            transform.DOKill();
            var explodeArea = _levelSettingsInitializer.GetExplosionAreaRadius(_shellCharge);
            
            transform.localScale = Vector3.zero;
            Destroy(gameObject,shellParticles.main.startLifetime.constantMax);
        }
    }
}
