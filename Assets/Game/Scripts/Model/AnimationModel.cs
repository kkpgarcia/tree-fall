using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Create Curve Animation Model")]
public class AnimationModel : ScriptableObject {
    public AnimationCurve Position;
    public AnimationCurve Rotation;
    public AnimationCurve Scale;
    public float Duration;
}
