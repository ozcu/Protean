using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
private Animator anim;
  private void Start(){
      anim = GetComponent<Animator>();

    }

    public void SaveGame(){
        GameManager.instance.SaveState();
    }

    public void LoadGame(){
        //teleport the player to beginning scene
        SceneManager.LoadScene("MainScene");
    }
    public void Update(){
        
        if(Input.GetKeyDown(KeyCode.Escape)){
            anim.SetTrigger("show"); 
 
        }
    }

    public void QuitGame(){
        Debug.Log("Quit from app");
        Application.Quit();
    } 
}
