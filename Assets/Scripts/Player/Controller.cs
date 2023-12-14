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

        if (Input.GetButtonDown("Jump"))
        {
            if(_player.coyoteTimeCounter > 0f)
                _player.Jump();

            else
                _player.Boost();
        }

        if(Input.GetButtonUp("Jump"))
        {
            _player.CutJump();
            _player.coyoteTimeCounter = 0f;
        }

    }

    public void ArtificialJump()
    {
        if (Input.GetButtonDown("Jump") && _player.IsFloor())
            _player.Jump();
    }
}
