using UnityEngine;

public class Trunk : MonoBehaviour {
    [SerializeField] private AnimationCurve Curve;
    [SerializeField] private float Duration;
    
    public void Move(Vector3 pos) {
        this.transform.MoveToUsingCurve(pos, Duration, Curve);
    }
}
