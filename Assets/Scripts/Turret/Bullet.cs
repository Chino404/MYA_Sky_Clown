using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    public float counter;
    ObjectPool<Bullet> _objectPool;


    void Update()
    {
        transform.position += transform.right* _speed * Time.deltaTime;
        
        counter += Time.deltaTime;
        
        if(counter>=2)
        {
            _objectPool.StockAdd(this);
            
        }
    }

    public void AddReference(ObjectPool<Bullet> op)
    {
        _objectPool = op;
    }

    public static void TurnOff(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
    public static void TurnOn(Bullet bullet)
    {
        bullet.counter = 0;
        bullet.gameObject.SetActive(true);
    }
}
