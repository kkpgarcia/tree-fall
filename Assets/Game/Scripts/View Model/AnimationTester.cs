using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTester : MonoBehaviour {
    public Vector3 endPosition;
    public AnimationCurve curve;
    public void Start() {
        Tweener tweener = this.transform.MoveToUsingCurve(endPosition, 1, curve);
        tweener.loopType = EasingControl.LoopType.PingPong;
        tweener.loopCount = -1;
    }
}
