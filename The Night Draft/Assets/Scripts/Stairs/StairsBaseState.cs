using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class StairsBaseState
    {
        protected readonly PolygonCollider2D[] _floor, _stairsLow, _stairsHigh;
        protected readonly BoxCollider2D[] _activeFloor, _stairsMiddle;
        protected readonly SpriteRenderer[] _handRailsLow;
        protected readonly IStairsStateSwitcher _stairsStateSwitcher;

        protected StairsBaseState(
            PolygonCollider2D[] floor,
            PolygonCollider2D[] stairsLow,
            PolygonCollider2D[] stairsHigh,
            BoxCollider2D[] activeFloor,
            BoxCollider2D[] stairsMiddle,
            SpriteRenderer[] handRailsLow,
            IStairsStateSwitcher stairsStateSwitcher)
        {
            _floor = floor;
            _stairsLow = stairsLow;
            _stairsHigh = stairsHigh;
            _activeFloor = activeFloor;
            _stairsMiddle = stairsMiddle;
            _handRailsLow = handRailsLow;
            _stairsStateSwitcher = stairsStateSwitcher;
        }
        protected void SetActive(Collider2D[] mass, bool s)
        {
            foreach (var item in mass)
                item.enabled = s;
        }

        protected void ChangeLayer(SpriteRenderer[] sps, int layer)
        {
            foreach (var sprite in sps)
                sprite.sortingOrder = layer;
        }

        protected virtual void Base() { }
        public abstract void Overpass();
        public abstract void GoUp();
        public abstract void GoDown();
    }
}
