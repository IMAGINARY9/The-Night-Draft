using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class IsFloorState : StairsBaseState
    {
        public IsFloorState(
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

        public override void Overpass()
        {
            SetActive(_stairsHigh, false);
            SetActive(_stairsMiddle, false);
            SetActive(_stairsLow, false);
            SetActive(_activeFloor, true);
            ChangeLayer(_handRailsLow, -2);
        }
        public override void GoUp()
        {
            SetActive(_activeFloor, false);
            SetActive(_stairsMiddle, true);
            SetActive(_stairsLow, true);
            SetActive(_stairsHigh, false);
            ChangeLayer(_handRailsLow, 2);
        }
        public override void GoDown()
        {
            SetActive(_activeFloor, false);
            SetActive(_stairsMiddle, true);
            SetActive(_stairsLow, false);
            SetActive(_stairsHigh, true);
            ChangeLayer(_handRailsLow, -2);
        }

        
    }
}