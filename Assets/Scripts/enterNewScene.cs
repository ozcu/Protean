using UnityEngine;
using UnityEngine.SceneManagement;


public class enterNewScene : Interactable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
       if(coll.name =="Player"){
           //Save Scene
           GameManager.instance.SaveState();
           

           //teleport the player
           string sceneName = sceneNames[Random.Range(0,sceneNames.Length)];
           SceneManager.LoadScene(sceneName);
           
           
       }
    }
}
