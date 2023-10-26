using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWithGyroscope : MonoBehaviour
{
    Gyroscope _gyroscope;
    [SerializeField] private float _rotationSpeed = 5;

    void Start()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("Sin Giroscopio");
        }
        else
        {
            _gyroscope = Input.gyro;
            _gyroscope.enabled = true;
        }
    }

    //void Update()
    //{

    //    //transform.rotation = gyro.attitude;

    //    //transform.rotation = new Quaternion(gyro.gravity.x, gyro.gravity.y, gyro.gravity.z, 0);

    //    transform.eulerAngles += _gyroscope.rotationRate * Time.deltaTime * _rotationSpeed;

    //    Debug.Log("Attitude: " + _gyroscope.attitude);
    //    Debug.Log("Gravity: " + _gyroscope.gravity);
    //    Debug.Log("RotationRate: " + _gyroscope.rotationRate);
    //}
}
