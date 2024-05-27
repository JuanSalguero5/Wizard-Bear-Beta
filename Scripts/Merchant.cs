using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shop.SetActive(true);
    }
}
