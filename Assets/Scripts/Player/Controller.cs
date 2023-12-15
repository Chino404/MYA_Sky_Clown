using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    Player _player;

    public Controller(Player player)
    {
        _player = player;
    }

    public void ArtificialUpdate()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        _player.Move(hor);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            _player.Dash();
        }

        if (!Input.GetButton("Jump"))
            _player.RestartDoubleJump();

        if (Input.GetButtonDown("Jump"))
            _player.Jump();

        if(Input.GetButtonUp("Jump"))
            _player.CutJump();


    }
}
