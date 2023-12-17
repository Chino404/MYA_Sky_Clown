using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Enemies
{
    
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
        transform.position += velocity * Time.deltaTime;
        transform.right = velocity;
    }
    
    public void Death()
    {
        Destroy(gameObject);
    }
}
