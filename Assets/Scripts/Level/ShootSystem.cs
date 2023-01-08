using System;
using UnityEngine;

namespace Level
{
    public class ShootSystem : MonoBehaviour
    {
        private ActiveShootState _activeShootState;

        public static event Action<ActiveShootState> ActiveStateChanged;
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                if (_activeShootState == ActiveShootState.Idle)
                {
                    StartCharging();
                }
            }
            else if(_activeShootState == ActiveShootState.Charge)
            {
                CompleteCharging();
            }
        }

        private void CompleteCharging()
        {
            _activeShootState = ActiveShootState.Idle;
            ActiveStateChanged?.Invoke(_activeShootState);
        }
        
        private void StartCharging()
        {
            _activeShootState = ActiveShootState.Charge;
            ActiveStateChanged?.Invoke(_activeShootState);
        }

        public enum ActiveShootState
        {
            Idle,
            Charge
        }
    }
}
