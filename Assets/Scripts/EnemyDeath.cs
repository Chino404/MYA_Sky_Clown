using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPlayer player = collision.gameObject.GetComponent<IPlayer>();
        if (player != null)
            Enemy.instance.Death();
    }
}
