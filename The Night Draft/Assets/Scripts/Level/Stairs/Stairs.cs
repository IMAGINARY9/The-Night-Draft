using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stairs : MonoBehaviour
    {
        [SerializeField] private PlayerMove _player;
        [SerializeField] private PolygonCollider2D[] _floor, _stairsLow, _stairsHigh;
        [SerializeField] private BoxCollider2D[] _activeFloor, _stairsMiddle;
        [SerializeField] private SpriteRenderer[] _handRailsLow;

        private State _currentState;
        private enum State
        {
            Is_floor = 0,
            Is_stairsLow = 1,
            Is_stairsMiddle = 2,
            Is_stairsHigh = 3,
            Is_activeFloor = 4
        }
        void Start()
        {
            _currentState = State.Is_floor;
        }

        private void SetActive(Collider2D[] mass, bool s)
        {
            foreach (var item in mass)
                item.enabled = s;
        }

        private void ChangeLayer(SpriteRenderer[] sps, int layer)
        {
            foreach (var sprite in sps)
                sprite.sortingOrder = layer;
        }
        private bool Check(Collider2D[] mass)
        {
            foreach (var item in mass)
                if (item.IsTouching(_player.Col))
                    return true;

            return false;
        }

        private void Go()
        {
            switch (_currentState)
            {
                case State.Is_floor:
                    SetActive(_stairsHigh, false);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_activeFloor, true);
                    ChangeLayer(_handRailsLow, -2);
                    break;
                case State.Is_stairsLow:
                    SetActive(_stairsHigh, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_activeFloor, false);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsMiddle:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsHigh:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_activeFloor:
                    SetActive(_activeFloor, true);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, -2);
                    break;
                    
            }
        }
        private void GoUp()
        {
            switch (_currentState)
            {
                case State.Is_floor:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsLow:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsMiddle:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, true);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsHigh:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_activeFloor:
                    SetActive(_activeFloor, true);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, -2);
                    break;
            }
        }
        private void GoDown()
        {
            switch (_currentState)
            {
                case State.Is_floor:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    ChangeLayer(_handRailsLow, -2);
                    break;
                case State.Is_stairsLow:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsMiddle:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_stairsHigh:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    ChangeLayer(_handRailsLow, 2);
                    break;
                case State.Is_activeFloor:
                    SetActive(_activeFloor, true);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, false);
                    ChangeLayer(_handRailsLow, -2);
                    break;
            }
        }

        void Update()
        {
            if (_player.DirY == 0)
                Go();
            else if (_player.DirY > 0)
                GoUp();
            else if (_player.DirY < 0)
                GoDown();


            if (Check(_floor))
                _currentState = State.Is_floor;
            else if (Check(_stairsLow))
                _currentState = State.Is_stairsLow;
            else if (Check(_stairsMiddle))
                _currentState = State.Is_stairsMiddle;
            else if (Check(_stairsHigh))
                _currentState = State.Is_stairsHigh;
            else if (Check(_activeFloor))
                _currentState = State.Is_activeFloor;
        }

    }
}