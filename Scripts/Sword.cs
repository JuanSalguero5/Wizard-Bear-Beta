using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private BoxCollider2D colSword;
    
    void Start()
    {
        colSword = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //compare the tag orc to destroy just the orc
        if (other.CompareTag("Orc")) 
        {
        Destroy(other.gameObject);
        }
    }
}
