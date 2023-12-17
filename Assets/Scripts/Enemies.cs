using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Transform[] wayPoints;
    public float speed;
    public float maxForce;
    public Vector3 velocity;
    [HideInInspector]public int _actualIndex;

    public Vector3 Seek(Vector3 pos)
    {
        var desired = pos - transform.position;
        desired.Normalize();
        desired *= speed;

        var steering = desired - velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        return steering;
    }
    public void AddForce(Vector3 dir)
    {
        velocity += dir;

        velocity = Vector3.ClampMagnitude(velocity, speed);
    }
}
