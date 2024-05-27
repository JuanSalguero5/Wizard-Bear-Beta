using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.Wound();
        }
    }
}
