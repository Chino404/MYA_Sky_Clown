
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Rewind, IObservableImpulse, IDamageable
{
    private View _view;
    private Controller _controller;
    private Rigidbody2D _myRB = default;
    private TrailRenderer _tr;

    [Header("Stats Player")]
    public float life;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _gravity; 
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _floorCheck;
    [SerializeField] private LayerMask _floorLayer;
    private bool _boosting;

    [SerializeField, Range(0,0.5f)]private float _coyoteTime = 0.2f;
    [HideInInspector] public float coyoteTimeCounter;

    public event Action onJump;

    private void Awake()
    {
        _view = new View(_renderer, this);
        _controller = new Controller(this);
        _myRB = GetComponent<Rigidbody2D>();
        _tr = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        _myRB.gravityScale = _gravity;
    }

    //private void FixedUpdate()
    //{
    //    _controller.ArtificialUpdate();
    //}

    void Update()
    {
        if(IsFloor())
        {
            coyoteTimeCounter = _coyoteTime;
            _boosting = false;
        }
        else
            coyoteTimeCounter -= Time.deltaTime;

        _controller.ArtificialUpdate();
    }

    public bool IsFloor()
    {
        return Physics2D.OverlapCircle(_floorCheck.position, 0.2f, _floorLayer);
    }

    public void Move(float hor)
    {
        _myRB.velocity = new Vector2(hor * _speed + Time.fixedDeltaTime, _myRB.velocity.y);
    }


    #region Jump
    public void Jump()
    {
        _myRB.velocity = new Vector2(_myRB.velocity.x, _jumpForce);
        onJump?.Invoke();
    }

    public void CutJump()
    {
        if(_myRB.velocity.x > 0 && !_boosting)
        {
            _myRB.velocity = new Vector2(_myRB.velocity.x, _myRB.velocity.y * 0.5f);
        }
    }

    public void Boost()
    {
        _boosting = true;

        foreach (var item in _impulse) //Llamo a todos los impulso que tenga suscrito
            item.Action(_myRB, transform, _tr);
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

    #region Memento

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

    #endregion
}
