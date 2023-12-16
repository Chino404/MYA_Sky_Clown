using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] wayPoints;
    public float speed;
    public float maxForce;
    Vector3 _velocity;
    int _actualIndex;
    public static Enemy instance;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        AddForce(Seek(wayPoints[_actualIndex].position));
        if(Vector3.Distance(transform.position, wayPoints[_actualIndex].position)<=0.3f)
        {
            _actualIndex++;
            if (_actualIndex >= wayPoints.Length)
                _actualIndex = 0;
        }
        transform.position += _velocity * Time.deltaTime;
        transform.right = _velocity;
    }
    Vector3 Seek(Vector3 pos)
    {
        var desired = pos - transform.position;
        desired.Normalize();
        desired *= speed;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        return steering;
    }
    public void AddForce(Vector3 dir)
    {
        _velocity += dir;

        _velocity = Vector3.ClampMagnitude(_velocity, speed);
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
