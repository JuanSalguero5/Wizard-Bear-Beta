using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("TreeLand");
    
    }

    public void ExitButton() 
    {
        Debug.Log("Exit");
        Application.Quit();



    }
}
