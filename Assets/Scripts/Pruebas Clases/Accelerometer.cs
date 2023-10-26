using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Accelerometer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _myRB;
    [SerializeField] private float _force;
    [SerializeField] private float _shakeForce = 1.5f;

    private void Start()
    {
        _myRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!SystemInfo.supportsAccelerometer) //Pregunta si el sistema en cuestion no tiene un acelerometro
        {
            Debug.Log("Sin acelerometro");
        }
        else
        {
            //Euler me devuelve grados
            Vector2 accelerationFixed = Quaternion.Euler(90, 90, 0) * Input.acceleration;

            _myRB.AddForce(accelerationFixed * _force);

            if (Input.acceleration.sqrMagnitude > _shakeForce)
            {
                //Shake System
            }
        }
    }
}
