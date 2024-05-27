using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public delegate void AdditionCoin(int coin);
    public static event AdditionCoin additionCoin;

    [SerializeField] private int amountCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          if(additionCoin != null) 
            {
                AddCoin();
                Destroy(this.gameObject);
            }
        
        }
    }

    private void AddCoin() 
    {
        additionCoin(amountCoin);
      
    }
}
