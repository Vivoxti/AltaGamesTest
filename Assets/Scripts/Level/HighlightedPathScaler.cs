using Level.CharacterShoot;
using UnityEngine;
using Zenject;

namespace Level
{
    public class HighlightedPathScaler : MonoBehaviour
    {
        private Character _character;
      
        [Inject]
        private void Inject(Character character)
        {
            _character = character;
        }

        private void OnEnable()
        {
            _character.SphereSizeChanged += OnSphereSizeChanged;
            _character.CriticalChargeLevelReached += OnCriticalChargeLevelReached;
        }

        private void OnDisable()
        {
            _character.SphereSizeChanged -= OnSphereSizeChanged;
            _character.CriticalChargeLevelReached -= OnCriticalChargeLevelReached;
        }

        private void OnSphereSizeChanged(Vector3 scale)
        {
            var newPathScale = transform.localScale;
            newPathScale.x = scale.x;
            transform.localScale = newPathScale;
        }
        
        private void OnCriticalChargeLevelReached()
        {
           Destroy(gameObject);
        }
    }
}