using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Enemies
{
    
    void Update()
    {
        AddForce(Seek(wayPoints[actualIndex].position));
        if (Vector3.Distance(transform.position, wayPoints[actualIndex].position) <= 0.3f)
        {
            actualIndex++;
            if (actualIndex >= wayPoints.Length)
                actualIndex = 0;
        }
        transform.position += velocity * Time.deltaTime;
        transform.right = velocity;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(damage);
            Debug.Log("hago daño");
        }
    }
}
