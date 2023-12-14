using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserverImpulse
{
    public void Action(Rigidbody2D rb2d, Transform transform, TrailRenderer trailRenderer);
}
