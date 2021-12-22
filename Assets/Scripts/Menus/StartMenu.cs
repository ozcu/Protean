using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("MainScene");
    }
    public void QuitGame(){
        Debug.Log("Quit from app");
        Application.Quit();
    }
   
    
}
