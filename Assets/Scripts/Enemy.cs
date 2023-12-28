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
        AddForce(Seek(wayPoints[actualIndex].position));
        if(Vector3.Distance(transform.position, wayPoints[actualIndex].position)<=0.3f)
        {
            actualIndex++;
            if (actualIndex >= wayPoints.Length)
                actualIndex = 0;
        }
        transform.position += velocity * Time.deltaTime;
        transform.right = velocity;
    }
    
    public void Death()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    public override void Save()
    {
        currentState.Rec(transform.position, transform.rotation);

    }

    public override void Load()
    {
        if (currentState.IsRemember())
        {
            var col = currentState.Remember();
            transform.position = (Vector3)col.parameters[0];
            transform.rotation = (Quaternion)col.parameters[1];

        }
    }
}
