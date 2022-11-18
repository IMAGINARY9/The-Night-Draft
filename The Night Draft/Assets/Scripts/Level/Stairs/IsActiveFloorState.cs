using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class IsActiveFloorState : StairsBaseState
    {
        public IsActiveFloorState(
            PolygonCollider2D[] floor,
            PolygonCollider2D[] stairsLow,
            PolygonCollider2D[] stairsHigh,
            BoxCollider2D[] activeFloor,
            BoxCollider2D[] stairsMiddle,
            SpriteRenderer[] handRailsLow,
            IStairsStateSwitcher stairsStateSwitcher)
            : base(floor, stairsLow, stairsHigh, activeFloor,
                  stairsMiddle, handRailsLow, stairsStateSwitcher)
        { }

        protected override void Base()
        {
            SetActive(_activeFloor, true);
            SetActive(_stairsMiddle, false);
            SetActive(_stairsLow, false);
            SetActive(_stairsHigh, false);
            ChangeLayer(_handRailsLow, -2);
        }
        public override void Overpass() => Base();
        public override void GoDown() => Base();
        public override void GoUp() => Base();
    }
}