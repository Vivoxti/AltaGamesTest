using System;
using System.Collections;
using Global;
using UnityEngine;
using Zenject;

namespace Level.CharacterShoot
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private ShellCreator shellCreator;
        [SerializeField] private GameObject sphereModel;
        [SerializeField] private AnimationCurve chargeTransferSpeedByTime;
        [SerializeField] private Gradient sphereColorByCharge;

        private ShootSystem _shootSystem;
        private LevelSettingsInitializer _levelSettingsInitializer;

        private Shell _shell;
        private Coroutine _chargeRoutine;
        private MeshRenderer _sphereMesh;
        
        public float _charge = 1f;
        
        private float _chargingTime;

        public event Action CriticalChargeLevelReached;
        public event Action<Vector3> SphereSizeChanged;
        
        [Inject]
        private void Inject(ShootSystem shootSystem,LevelSettingsInitializer levelSettingsInitializer)
        {
            _shootSystem = shootSystem;
            _levelSettingsInitializer = levelSettingsInitializer;
        }

        private void Start()
        {
            _sphereMesh = sphereModel.GetComponent<MeshRenderer>();
        }

        private void OnEnable()
        {
            _shootSystem.ActiveStateChanged += OnActiveStateChanged;
        }

        private void OnActiveStateChanged(ShootSystem.ActiveShootState state)
        {
            if (state == ShootSystem.ActiveShootState.Charge)
            {
                ActivateChargeMode();
            }
            else if(_shell != null)
            {
                StopCoroutine(_chargeRoutine);
                _shell.Launch();
            }
        }

        private void ActivateChargeMode()
        {
            _chargingTime = 0;
            _shell = shellCreator.CreateShell();
            _chargeRoutine = StartCoroutine(ChargeRoutine());
        }

        private IEnumerator ChargeRoutine()
        {
            while (true)
            {
                TransferCharge();
                yield return null;
                _chargingTime += Time.deltaTime;
            }
        }

        private void TransferCharge()
        {
            var chargeValue = chargeTransferSpeedByTime.Evaluate(_chargingTime);
            ReduceCharacterCharge(chargeValue);
            _shell.Boost(chargeValue);
        }
        
        private void ReduceCharacterCharge(float chargeValue)
        {
            _charge -= chargeValue;
            
            sphereModel.transform.localScale = Vector3.one * _charge;

            var currentColorValue = (1f - _levelSettingsInitializer.MinCharacterSize) * _charge + _levelSettingsInitializer.MinCharacterSize;
            _sphereMesh.material.color = sphereColorByCharge.Evaluate(currentColorValue);
            
            SphereSizeChanged?.Invoke(sphereModel.transform.localScale);

            if (!(_charge <= _levelSettingsInitializer.MinCharacterSize)) return;
            CriticalChargeLevelReached?.Invoke();
            UnityEngine.Debug.LogError("criticalsize");
        }
        
        private void OnDisable()
        {
            _shootSystem.ActiveStateChanged -= OnActiveStateChanged;
        }
    }
}
