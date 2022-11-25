using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class StairsBehaviour : MonoBehaviour, IStairsStateSwitcher
    {
        [SerializeField] private Player _player;
        [SerializeField] private PolygonCollider2D[] _floor, _stairsLow, _stairsHigh;
        [SerializeField] private BoxCollider2D[] _activeFloor, _stairsMiddle;
        [SerializeField] private SpriteRenderer[] _handRailsLow;

        private StairsBaseState _currentState;
        private List<StairsBaseState> _allStates;

        private void Start()
        {
            _allStates = new()
            {
                new IsFloorState(_floor, _stairsLow, _stairsHigh, _activeFloor, _stairsMiddle, _handRailsLow, this),
                new IsStairsHighState(_floor, _stairsLow, _stairsHigh, _activeFloor, _stairsMiddle, _handRailsLow, this),
                new IsStairsMiddle(_floor, _stairsLow, _stairsHigh, _activeFloor, _stairsMiddle, _handRailsLow, this),
                new IsStairsLowState(_floor, _stairsLow, _stairsHigh, _activeFloor, _stairsMiddle, _handRailsLow, this),
                new IsActiveFloorState(_floor, _stairsLow, _stairsHigh, _activeFloor, _stairsMiddle, _handRailsLow, this),

            };
            _currentState = _allStates[0];
        }

        private void Overpass()
            => _currentState.Overpass();
        private void GoUp()
            => _currentState.GoUp();
        private void GoDown()
            => _currentState.GoDown();

        protected bool Check(Collider2D[] mass)
        {
            foreach (var item in mass)
                if (item.IsTouching(_player.Col))
                    return true;

            return false;
        }

        void Update()//
        {
            if (_player.Vertical == 0)
                Overpass();
            else if (_player.Vertical > 0)
                GoUp();
            else if (_player.Vertical < 0)
                GoDown();

            if (Check(_floor))
                SwitchState<IsFloorState>();
            else if (Check(_stairsLow))
                SwitchState<IsStairsLowState>();
            else if (Check(_stairsMiddle))
                SwitchState<IsStairsMiddle>();
            else if (Check(_stairsHigh))
                SwitchState<IsStairsHighState>();
            else if (Check(_activeFloor))
                SwitchState<IsActiveFloorState>();

        }


        public void SwitchState<T>() where T : StairsBaseState
        {
            var state = _allStates.FirstOrDefault(s => s is T);
            _currentState = state;
        }
    }
}