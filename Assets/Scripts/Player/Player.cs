
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Rewind, IObservableImpulse, IDamageable
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] float _gravity; 
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField]ForceMode2D _jumpForceMode;
    public float life;

    View _view;
    Controller _controller;
    public event Action onJump;

    Rigidbody2D _myRB = default;
    public bool inFloor = default;

    private void Start()
    {
        _view = new View(_renderer, this);
        _controller = new Controller(this);
        _myRB = GetComponent<Rigidbody2D>();
    }

    //private void FixedUpdate()
    //{
    //    _controller.ArtificialUpdate();
    //}

    void Update()
    {
       // _controller.ArtificialJump();
        _controller.ArtificialUpdate();
        Gravity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)//si colisiona con el piso
        {
            inFloor = true;

        }
    }

    public void Move(float hor)
    {
        _myRB.AddForce((transform.right * hor).normalized * _speed * Time.fixedDeltaTime, ForceMode2D.Force);
        //transform.position += transform.right * hor * _speed * Time.deltaTime;
    }


    #region Jump
    public void Gravity()
    {
        _myRB.gravityScale = _gravity;
    }

    public void Jump()
    {
        if (inFloor)
        {
            inFloor = false;
            _myRB.AddForce(Vector2.up * _jumpForce, _jumpForceMode);
            onJump?.Invoke();
            Debug.Log("salto");
        }

        foreach(var item in _impulse) //Llamo a todos los impulso que tenga suscrito
            item.Action(_myRB/*, _controller.GetMovementInput()*/);
    }

    #endregion

    public List<IObserverImpulse> _impulse = new List<IObserverImpulse>();

    public void Subscribe(IObserverImpulse obs)
    {
        if(!_impulse.Contains(obs))
            _impulse.Add(obs);
    }

    public void Unsubscribe(IObserverImpulse obs)
    {
        if(_impulse.Contains(obs))
            _impulse.Remove(obs);
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
    }

    public override void Save()
    {
        currentState.Rec(transform.position, transform.rotation, life);
    }

    public override void Load()
    {
        if(currentState.IsRemember())
        {
            var col = currentState.Remember();
            transform.position = (Vector3)col.parameters[0];
            transform.rotation = (Quaternion)col.parameters[1];
            life = (float)col.parameters[2];
        }
    }
}
