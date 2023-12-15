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

        player.viewJump += JumpFeedBack;
        actualMethod = Jump;
    }

    public void JumpFeedBack()
    {
        actualMethod();
    }

    public void Jump()
    {
        if (_player.IsFloor())
        {
            _renderer.color = Color.green;
        }
        else
        {
            _renderer.color = Color.yellow;
        }
    }
}
