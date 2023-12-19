using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    private Player _player;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Color _baseColor;
    private Color _dmgColor;

    private float _hor;
    private bool _jumping;

    delegate void viewMethod();
    viewMethod actualMethod;

    public View(Player player, SpriteRenderer spriteRenderer , Animator animator, Color baseColor, Color dmgColor)
    {
        _player = player;
        _spriteRenderer = spriteRenderer;
        _animator = animator;
        _baseColor = baseColor;
        _dmgColor = dmgColor;

        actualMethod += Walikng;
        actualMethod += Jump;
        //actualMethod += GetDamage;

    }

    public void FeedBack(float hor, bool jumping)
    {
        _jumping = jumping;
        _hor = hor;

        actualMethod();
    }

    
    public void GetDamage()
    {
        _player.StartCoroutine(ChangeColor());
    }
    IEnumerator ChangeColor()
    {
        _spriteRenderer.color = _dmgColor;
        yield return new WaitForSeconds(0.5f);
        _spriteRenderer.color = _baseColor;

    }

    public void Jump()
    {
        _animator.SetBool("Jump", _jumping);
    }

    public void Walikng()
    {
        _animator.SetFloat("Horizontal", Mathf.Abs(_hor));
    }
}
