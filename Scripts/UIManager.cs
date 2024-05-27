using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalCoin;
    private int totalObjects;
    private int priceObject;

   

    [SerializeField] private TMP_Text coinText;
    [SerializeField] private List<GameObject> listOfHearts;
    [SerializeField] private Sprite heartOff, heartOn;
    [SerializeField] private GameObject boxText;
    [SerializeField] private TMP_Text textDialogue;

    [SerializeField] private GameObject equipementPanel;

    private void Start()
    {
        Coin.additionCoin += AdditionCoin;
    }
     
    private void AdditionCoin(int coin) 
    {
       totalCoin += coin;
       coinText.text = totalCoin.ToString();
    }

    public void RestHearts(int index) 
    {
       Image imageHearth = listOfHearts[index].GetComponent<Image>();
        imageHearth.sprite = heartOff;
    
    }

    public void AddHearths(int index) 
    {
        Image imageHearth = listOfHearts[index].GetComponent<Image>();
        imageHearth.sprite = heartOn;

    }

    public void SetBoxText (bool activated) 
    {
        boxText.SetActive(activated);
    }

    public void ShowText (string text)
    {
     textDialogue.text = text.ToString();
    
    }

    #region SHOP

    public void PriceObject (string item) 
    {
      switch (item) 
        {
            case "ButtonMinPotion":
                priceObject = 1;
                break;
        }
    
    }

    public void AcquireObject(string item)
    {
        PriceObject(item);

        if (priceObject <= totalCoin && totalObjects < 3)
        {
            totalObjects++;
            totalCoin -= priceObject;
            coinText.text = totalCoin.ToString();
             
            GameObject equipement = (GameObject)Resources.Load(item);
            Instantiate(equipement, Vector3.zero, Quaternion.identity, equipementPanel.transform);
        }
    }

    #endregion

   
}
