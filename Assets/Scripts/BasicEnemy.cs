using System;
using UnityEngine;

public class BasicEnemy : Enemy
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player.TakeDamage();
        }
    }
}
