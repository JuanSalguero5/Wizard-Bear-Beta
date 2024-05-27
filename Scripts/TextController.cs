using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField, TextArea(3, 10)] private string[] arrayText;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private PlayerMovement player;

    private int index;

    private void Awake()
    {
        //Player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnMouseDown()
    {
        float distance = Vector2.Distance(this.gameObject.transform.position, player.transform.position);
        if (distance <= 2) 
        {
            uIManager.SetBoxText(true);
            player.ImTalking(true);
            ActivatedPoster();
        }
    }

    private void ActivatedPoster() 
    {
        if (index <  arrayText.Length)
        {
            uIManager.ShowText(arrayText[index]);
            index++;      
        }
        else 
        {
            uIManager.SetBoxText(false);
            player.ImTalking(false);
        }
    }
}
