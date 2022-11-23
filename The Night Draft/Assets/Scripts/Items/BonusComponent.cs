using System.Collections;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class BonusComponent : MonoBehaviour
    {
        public static Action<BonusComponent> BonusActivated;
        public Action Over;

        //public void Activate(float duration)
        //{
        //    StartCoroutine(ActingRoutine());
        //    //BonusActivated?.Invoke(this);
        //    IEnumerator ActingRoutine()
        //    {
        //        yield return new WaitForSeconds(duration);
        //        OnBonusOver();
        //    }
        //}

        public void Deactivate() => OnBonusOver();
        protected virtual void OnBonusOver() => Over?.Invoke();

        //private void Start() => LevelManager.Restart += Deactivate;
        //private void OnDestroy() => LevelManager.Restart -= Deactivate;
    }
}