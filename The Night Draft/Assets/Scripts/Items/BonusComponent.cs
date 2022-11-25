using System.Collections;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class BonusComponent : MonoBehaviour
    {
        public static Action<BonusComponent> BonusActivated;
        public Action Over;
        public virtual void Deactivate() => OnBonusOver();
        protected virtual void OnBonusOver() => Over?.Invoke();
    }
}