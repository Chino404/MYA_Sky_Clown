using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemies : MonoBehaviour
{
    public Transform[] wayPoints;
    public float speed;
    public float maxForce;
    [HideInInspector]public Vector3 velocity;
    [HideInInspector]public int actualIndex;
    public float damage;


    public Vector3 Seek(Vector3 pos)
    {
        var desired = pos - transform.position;
        desired.Normalize();
        desired *= speed;

        //var steering = desired - velocity;
        //steering = Vector3.ClampMagnitude(steering, maxForce);

        //return steering;
        return desired;
    }
    public void AddForce(Vector3 dir)
    {
        velocity += dir;

        velocity = Vector3.ClampMagnitude(velocity, speed);
    }
}
