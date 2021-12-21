
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> inventoryWeaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;

      private void Awake(){
          //Prevent double instances
        if(GameManager.instance != null){
            Destroy(gameObject); //Game manager itself
            Destroy(player.gameObject); 
            Destroy(floatingTextManager.gameObject); 

            return;
        }else if (GameManager.instance ==null){

            //PlayerPrefs.DeleteAll(); deletes saved data 
            instance = this;
            SceneManager.sceneLoaded += LoadState;  //on scene load event fire loadstate function
        }
    }

    //Floating Text
    public floatingTextManager floatingTextManager;
    public void ShowText(string msg,int fontSize,Color color,Vector3 position,Vector3 motion,float duration){
        floatingTextManager.Show( msg, fontSize, color, position, motion, duration);
    }

    //Logic
    public int coins;
    public int experience;


    /*
    * INT preferredSkin
    * INT coins
    * INT experience
    * INT weaponLevel
    * -> ARRAY Of Inv item?
    */

    public void SaveState(){
        Debug.Log("SaveState");
        string scene = "";

        scene += "0" + "|";
        scene += coins.ToString() + "|";
        scene += experience.ToString() + "|";
        scene += "0" + "|";

        PlayerPrefs.SetString("SaveState",scene);
        
    }
    public void LoadState(Scene scene,LoadSceneMode mode){
        Debug.Log("LoadState");
        
        //Debug.Log(GameManager.instance.inventoryWeaponSprites[0]);

        //Teleport player to spawnPoint on load
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
     
        if(!PlayerPrefs.HasKey("SaveState")){
            return;
        }
       
        DontDestroyOnLoad(gameObject);
        
        string[] data =PlayerPrefs.GetString("SaveState").Split('|');

        //Change playerSkin
        //playerskin = data[0];

        //Assign Coins
        coins = int.Parse(data[1]);

        //Assign Experience
        experience = int.Parse(data[2]);

        //Assign weaponLevel 
        //weaponLevel = int.Parse(data[3]);
    }

}
