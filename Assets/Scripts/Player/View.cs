using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View
{
    private SpriteRenderer _renderer;
    public Material onMoveMaterial;
    bool _inFloor;
    //private Animator _anim;

    public View(SpriteRenderer renderer/*,Controller controller, Animator anim*/, Player player, ref bool inFloor)
    {
        _renderer = renderer;
        _inFloor = inFloor;
        player.onJump += OnJump;

    }

    public void OnJump()
    {
        _renderer.color = Color.yellow;
    }

    public void InFloor()
    {
        _renderer.color = Color.green;
    }

}
