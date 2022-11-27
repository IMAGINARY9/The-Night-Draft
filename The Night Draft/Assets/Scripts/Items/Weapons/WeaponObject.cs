using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "WeaponObject", menuName = "WeaponObject", order = 0)]
    public class WeaponObject : ScriptableObject
    {
        [field: SerializeField] public float Angle { get; private set; }
        [field: SerializeField] public float Recoil { get; private set; }
        [field: SerializeField] public Vector2 BulletDirectionModifier { get; private set; }
    }
}