using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    private Player _player;
    private View _view;
    private bool jumping = false;

    public Controller(Player player, View view)
    {
        _player = player;
        _view = view;
    }

    public void ArtificialUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        _player.Move(hor);
        _view.FeedBack(hor, jumping);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            _player.Dash();
        }

        if (!Input.GetButton("Jump"))
        {
            _player.RestartDoubleJump();
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumping = true;
            _player.Jump();
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumping = false;
            _player.CutJump();
        }
    }
}
