using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Create Curve Animation Model")]
public class AnimationModel : ScriptableObject {
    /**
    * This is an animation container for the animation library
    */
    public AnimationCurve Position;
    public AnimationCurve Rotation;
    public AnimationCurve Scale;
    public float Duration;
}
