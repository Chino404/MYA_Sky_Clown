using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //public float speed;
    public IAdvance myMovement;
    //public string type;
    //public Transform[] waypoints;
    //int _actualIndex;
    Vector3 _velocity;
    //public float maxForce;



    private void Start()
    {
        
            myMovement = new NormalPlatform(transform, _velocity);

       
    }

    void Update()
    {
        myMovement.Advance();
        //AddForce(Seek(waypoints[_actualIndex].position));
        //if (Vector3.Distance(transform.position, waypoints[_actualIndex].position) <= 0.3f)
        //{
        //    _actualIndex++;

        //    if (_actualIndex >= waypoints.Length)
        //    {
               
        //        _actualIndex = 0;

        //    }
        //}

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            myMovement = new SinPlatform(transform, _velocity);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            myMovement = new NormalPlatform(transform, _velocity);

    }
    public void ChangeMove(IAdvance newAdvance)
    {
        myMovement = newAdvance;
    }

    //Vector3 Seek(Vector3 target)
    //{
    //    var desired = target - transform.position;
    //    desired.Normalize();
    //    desired *= speed;

    //    var steering = desired - _velocity;
    //    steering = Vector3.ClampMagnitude(steering, maxForce);

        
    //    return steering;
    //}

    //public void AddForce(Vector3 dir)
    //{
    //    _velocity += dir;

    //    _velocity = Vector3.ClampMagnitude(_velocity, speed);
    //}
}
