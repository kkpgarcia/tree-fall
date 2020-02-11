using UnityEngine;

public class Trunk : MonoBehaviour {
    [SerializeField] private float Duration;
    [SerializeField] private AnimationModel AnimationModel;
    public void Move(Vector3 pos) {
        this.transform.MoveToUsingCurve(pos, AnimationModel.Duration, AnimationModel.Position);
    }
}
