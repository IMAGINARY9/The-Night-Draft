using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class IsStairsMiddle : StairsBaseState
    {
        public IsStairsMiddle(
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
            SetActive(_activeFloor, false);
            SetActive(_stairsMiddle, true);
            SetActive(_stairsLow, true);
            ChangeLayer(_handRailsLow, 2);
        }
        public override void Overpass()
        {
            Base();
            SetActive(_stairsHigh, false);
        }
        public override void GoUp()
        {
            Base();
            SetActive(_stairsHigh, true);
        }
        public override void GoDown()
        {
            Base();
            SetActive(_stairsHigh, false);
        }

    }
}