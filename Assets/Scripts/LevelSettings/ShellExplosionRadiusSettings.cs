using UnityEngine;

namespace LevelSettings
{
    [CreateAssetMenu(fileName = "Shell Explosion Radius Settings", menuName = "Custom/Level/ShellExplosionRadiusSettings")]
    public class ShellExplosionRadiusSettings : ScriptableObject
    {
        [SerializeField] private AnimationCurve explosionRadiusByShellSize;

        public float GetExplosionRadius(float shellSize)
        {
            return explosionRadiusByShellSize.Evaluate(shellSize);
        }
    }
}
