using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float _seconds; //segundos de cooldown
    [SerializeField] int _bulletQuantity;// cantidad de balas que instancio al principio
    public Bullet prefab;
    //public GameObject turret;
    
    public Transform target;

    Factory<Bullet> _factory;
    ObjectPool<Bullet> _objectPool;

    bool _inZone;
    bool _coolDown;
    
    //public GameObject shooter;
    

    private void Start()
    {
        _factory = new BulletFactory(prefab);

        _objectPool = new ObjectPool<Bullet>(_factory.GetObj,Bullet.TurnOff,Bullet.TurnOn, _bulletQuantity);
    }

    void Update()
    {
        if(_inZone)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            //turret.transform.LookAt(new Vector3(transform.position.x, transform.position.y,target.position.x));
            if (!_coolDown)
                StartCoroutine(Shoot());
        }
        
    }
    IEnumerator Shoot()
    {
        _coolDown = true;
        var bullet = _objectPool.Get();
        bullet.AddReference(_objectPool);
        bullet.transform.position = transform.position;
        bullet.transform.right = transform.right;
        yield return new WaitForSeconds(_seconds);
        _coolDown = false;

    }

    private void OnTriggerEnter2D(Collider2D objectTriggered)
    {
        if (objectTriggered.transform == target)
        {
            _inZone = true;
            Debug.Log("en zona");
        }
    }


    private void OnTriggerExit2D(Collider2D objectTriggered)
    {
        if (objectTriggered.transform == target)
        {
            _inZone = false;
            Debug.Log("fuera de zona");
        }

    }

    
}
