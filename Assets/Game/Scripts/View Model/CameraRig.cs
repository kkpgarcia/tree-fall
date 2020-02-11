using UnityEngine;
using UnityEngine.Events;

public class CameraRig : MonoBehaviour {
    public const string OnMoveNotification = "CameraRig.OnMove";
    public AnimationCurve AnimationCurve;
    public float MovementDuration;
    public void Start() {
        this.AddObserver(OnMove, OnMoveNotification);
    }

    public void OnDestroy() {
        this.RemoveObserver(OnMove, OnMoveNotification);
    }

    public void OnMove(object sender, object args) {
        InfoEventArgs<Vector3, UnityAction> info = (InfoEventArgs<Vector3, UnityAction>) args;
        Vector3 target = info.Arg0;
        this.transform.MoveToUsingCurve(target, MovementDuration, AnimationCurve)
            .CompletedEvent += (s,a) => {
                info.Arg1();
            };
    }
}
