using UnityEngine;

public interface IBounceAnimation
{
    public float BounceTouchDuration { get; }
    public float BounceShowDuration { get; }
    public float BounceHideDuration { get; }

    public void BounceTouch(Transform target);
    public void BounceShow(Transform target);
    public void BounceHide(Transform target);
}
