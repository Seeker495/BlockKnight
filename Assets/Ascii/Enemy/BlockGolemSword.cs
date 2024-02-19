using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGolemSword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (other.TryGetComponent(out player))
        {
            player.Damage();
        }
    }
}
