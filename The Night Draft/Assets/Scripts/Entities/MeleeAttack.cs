using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MeleeAttack : MonoBehaviour
    {
        [SerializeField] private Overlap _checkDist;
        [SerializeField] private Weapon _weapon;

        public void Attack()
        {
            if(_checkDist.IsCollided)
            {
                print("attack");
                _weapon.Use();
            }
        }
    }
}