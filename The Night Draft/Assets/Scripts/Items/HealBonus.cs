using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class HealBonus : Bonus
    {
        protected override void OnCollected(GameObject collector)
        {
            if (collector.TryGetComponent<IHealable>(out var medUser))
                medUser.ApplyHeal();
        }
    }
}