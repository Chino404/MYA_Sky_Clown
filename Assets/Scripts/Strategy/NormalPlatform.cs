using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : IAdvance
{
    Transform _transform;
    Vector3 _velocity;

    public NormalPlatform(Transform tr, Vector3 newSpeed)
    {
        _transform = tr;
        _velocity = newSpeed;
    }
   public void Advance()
   {
        _velocity = _transform.right;
        _transform.position +=  Time.deltaTime * _velocity;

   }
}
