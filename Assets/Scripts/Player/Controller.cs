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
            _player.Jump();

    }

    public void ArtificialJump()
    {
        if (Input.GetButtonDown("Jump"))
            _player.Jump();
    }
}
