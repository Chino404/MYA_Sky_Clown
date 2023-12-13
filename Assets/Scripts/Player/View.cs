using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    private SpriteRenderer _renderer;
    private Player _player;
    public Material onMoveMaterial;

    delegate void JumpView();
    JumpView actualMethod;
    //private Animator _anim;

    public View(SpriteRenderer renderer, Player player)
    {
        _renderer = renderer;
        _player = player;

        player.onJump += JumpFeedBack;
        actualMethod = Jump;
    }

    public void JumpFeedBack()
    {
        actualMethod();
    }

    public void Jump()
    {
        if (_player.inFloor)
        {
            _renderer.color = Color.green;
        }
        else
        {
            _renderer.color = Color.yellow;
        }
    }

    public void OnJump()
    {
        _renderer.color = Color.yellow;
        actualMethod = InFloor;
    }

    public void InFloor()
    {
        _renderer.color = Color.green;
        actualMethod = OnJump;
    }
}
