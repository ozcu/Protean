using UnityEngine;


public class enterNewScene : Interactable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
       if(coll.name =="Player"){
           //teleport the player
           string sceneName = sceneNames[Random.Range(0,sceneNames.Length)];
           UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
       }
    }
}
