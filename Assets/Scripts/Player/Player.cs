
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Player : Rewind, IObservable, IDamageable, IPlayer
{
    private View _view;
    private Controller _controller;
    private Rigidbody2D _myRB = default;
    private Animator _animator;
    private SpriteRenderer _spr;
    private TrailRenderer _tr;

    [Header("Stats Player")]
    [SerializeField] private float _gravity; 
    public float maxLife;
    private float _actualLife;
    public Color baseColor;
    public Color dmgColor;
    private bool _isFacingRight = true;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private bool _doubleJump;
    [SerializeField, Range(0,0.5f)] private float _coyoteTime = 0.2f;
    private float _coyoteTimeCounter;
    [SerializeField] private float _dashingPower = 24f;
    [SerializeField] private float _dashingCooldown = 0.5f;
    private float _dashingTime = 0.2f;
    private bool _canDash = true;
    private bool _isDashing;

    private bool _boostReady;
    private bool _boosting;

    [Header("Reference")]
    [SerializeField] private Transform _floorCheck;
    [SerializeField] private LayerMask _floorLayer;

    public event Action viewDmg;

    private void Awake()
    {
        _myRB = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spr = GetComponent<SpriteRenderer>();
        _tr = GetComponent<TrailRenderer>();
        _view = new View(this, _spr ,_animator, baseColor, dmgColor);
        _controller = new Controller(this,_view);
    }

    private void Start()
    {
        _myRB.gravityScale = _gravity;
        _actualLife = maxLife;
        _spr.color = baseColor;
    }

    void Update()
    {
        if(IsFloor())
        {
            _coyoteTimeCounter = _coyoteTime;
            _boosting = false;
        }
        else
            _coyoteTimeCounter -= Time.deltaTime;

        _controller.ArtificialUpdate();

        if (_actualLife <= 0)
            PauseManager.instance.GameOver();
    }

    public void Move(float hor)
    {
        if (_isDashing)
            return;

        Flip(hor);
        _myRB.velocity = new Vector2(hor * _speed + Time.fixedDeltaTime, _myRB.velocity.y);
    }

    private void Flip(float hor)
    {
        if(_isFacingRight && hor <0f || !_isFacingRight && hor > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public bool IsFloor()
    {
        return Physics2D.OverlapCircle(_floorCheck.position, 0.2f, _floorLayer);
    }

    #region Jump
    public void Jump()
    {
        if (_isDashing)
            return;

        if(_boostReady) Boost();

        else if (_coyoteTimeCounter > 0f || _doubleJump)
        {
            _myRB.velocity = new Vector2(_myRB.velocity.x, _jumpForce);
            _doubleJump = !_doubleJump;
            //viewDmg?.Invoke();
        }

    }

    public void CutJump()
    {
        if(_myRB.velocity.x > 0 && !_boosting)
        {
            _myRB.velocity = new Vector2(_myRB.velocity.x, _myRB.velocity.y * 0.5f);
            _coyoteTimeCounter = 0;
        }
    }


    public void RestartDoubleJump()
    {
        if (IsFloor()) _doubleJump = false;
    }

    public void Boost()
    {
        _boosting = true;
        foreach (var item in _impulse) //Llamo a todos los impulso que tenga suscrito
            item.Boost(_myRB, transform, _tr);
    }
    #endregion

    #region Dash
    public void Dash()
    {
        if (_canDash)
        {
            StartCoroutine(Dashing());
        }
    }

    IEnumerator Dashing()
    {
        _canDash = false;
        _isDashing = true;
        float originalGravity = _myRB.gravityScale;
        _myRB.gravityScale = 0f;
        _myRB.velocity = new Vector2(transform.localScale.x * _dashingPower, 0f);
        _tr.emitting = true;
        yield return new WaitForSeconds(_dashingTime);
        _tr.emitting = false;
        _myRB.gravityScale = originalGravity;
        _isDashing = false;
        yield return new WaitForSeconds(_dashingCooldown);
        _canDash = true;
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
        _actualLife -= damage;
        EventManager.Trigger("LifeBar", maxLife, _actualLife);

        if (_actualLife <= 0f)
        {
            _actualLife = 0f;
            Debug.Log("Player Death");
        }
        _view.GetDamage();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObserverImpulse>() != null)
            _boostReady = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IObserverImpulse>() != null)
            _boostReady = false;
    }

    #region Memento

    public override void Save()
    {
        currentState.Rec(transform.position, transform.rotation, _actualLife);
    }

    public override void Load()
    {
        if(currentState.IsRemember())
        {
            var col = currentState.Remember();
            
            transform.position = (Vector3)col.parameters[0];
            transform.rotation = (Quaternion)col.parameters[1];
            _actualLife = (float)col.parameters[2];
        }
    }

    #endregion
}
