using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stairs : MonoBehaviour
    {
        [SerializeField] private PlayerMove _player;
        [SerializeField] private PolygonCollider2D[] _floor, _stairsLow, _stairsHigh;
        [SerializeField] private BoxCollider2D[] _activeFloor, _stairsMiddle/*, //_activeCeil*/;
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


        private void SetActive(BoxCollider2D[] mass, bool s)
        {
            foreach (var item in mass)
                item.enabled = s;
        }
        private void SetActive(PolygonCollider2D[] mass, bool s)
        {
            foreach (var item in mass)
                item.enabled = s;
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
                    break;
                case State.Is_stairsLow:
                    SetActive(_stairsHigh, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_activeFloor, false);
                    break;
                case State.Is_stairsMiddle:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    break;
                case State.Is_stairsHigh:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    break;
                case State.Is_activeFloor:
                    SetActive(_activeFloor, true);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, false);
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
                    break;
                case State.Is_stairsLow:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    break;
                case State.Is_stairsMiddle:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, true);
                    break;
                case State.Is_stairsHigh:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    break;
                case State.Is_activeFloor:
                    SetActive(_activeFloor, true);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, false);
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
                    break;
                case State.Is_stairsLow:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    break;
                case State.Is_stairsMiddle:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, true);
                    SetActive(_stairsHigh, false);
                    break;
                case State.Is_stairsHigh:
                    SetActive(_activeFloor, false);
                    SetActive(_stairsMiddle, true);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, true);
                    break;
                case State.Is_activeFloor:
                    SetActive(_activeFloor, true);
                    SetActive(_stairsMiddle, false);
                    SetActive(_stairsLow, false);
                    SetActive(_stairsHigh, false);
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

        private bool Check(PolygonCollider2D[] mass)
        {
            foreach (var item in mass)
                if (item.IsTouching(_player.Col))
                    return true;

            return false;
        }
        private bool Check(BoxCollider2D[] mass)
        {
            foreach (var item in mass)
                if (item.IsTouching(_player.Col))
                    return true;

            return false;
        }
        

    }
}