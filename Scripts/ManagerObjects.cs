using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerObjects : MonoBehaviour
{
    public enum EquipementObjects 
    {
       MinPotion,
       MedPotion,
       SpeedPotion,
    };

    [SerializeField] EquipementObjects equipementObjects;

    public void UseObject()
    {

        PlayerMovement player = GameObject.FindObjectOfType<PlayerMovement>();

    switch (equipementObjects)
        {
        case EquipementObjects.MinPotion:
                player.Heal();
                Debug.Log("heal a point of health");
                break;
        case EquipementObjects.MedPotion:
                Debug.Log("heal a two points of health");
                break;
        case EquipementObjects .SpeedPotion:
                Debug.Log("Add speed to the player");
                break;
        }

        Destroy(this.gameObject);
    }
}
