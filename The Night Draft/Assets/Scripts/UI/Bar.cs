using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Bar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;


        public void SetMax(int value)
        {
            _slider.maxValue = value;
            _slider.value = value;
        }
        public void Set(int value)
        {
            _slider.value = value;
        }
        public void SetMax(float value)
        {
            _slider.maxValue = value;
            _slider.value = value;
        }
        public void Set(float value)
        {
            _slider.value = value;
        }

    }
}