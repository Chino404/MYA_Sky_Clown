using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinPlatform : IAdvance
{
    Transform _transform;
    Vector3 _velocity;
    public SinPlatform(Transform tr, Vector3 newSpeed)
    {
        _transform = tr;
        _velocity = newSpeed;
    }
    public void Advance()
    {
        _velocity = _transform.up;
        _transform.position +=  Time.deltaTime * _velocity;
        
    }


}
