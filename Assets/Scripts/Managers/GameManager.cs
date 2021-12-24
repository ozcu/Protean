
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
  
    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> inventoryWeaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

  

    #region Singleton
      private void Awake(){
          //Prevent double instances
        if(GameManager.instance != null){
            Destroy(this.gameObject); //Game manager itself
            Destroy(player.gameObject); 
            Destroy(floatingTextManager.gameObject); 
            Destroy(EventSystem.current.gameObject);
            Destroy(GameObject.Find("PlayerMenu"));
            Destroy(GameObject.Find("MainMenuContainer"));
            Destroy(GameObject.Find("HUDContainer"));


            return;
        }else if (GameManager.instance ==null){

            //PlayerPrefs.DeleteAll(); deletes saved data 
            instance = this;
            SceneManager.sceneLoaded += LoadState;  //on scene load event fire loadstate function
        }
    }
    #endregion
    //Floating Text
    public floatingTextManager floatingTextManager;
    public void ShowText(string msg,int fontSize,Color color,Vector3 position,Vector3 motion,float duration){
        floatingTextManager.Show( msg, fontSize, color, position, motion, duration);
    }

    //References
    public Player player;

    //Logic
    public int coins;
    public int experience;


    /*
    * INT preferredSkin
    * INT coins
    * INT experience
    * INT weaponLevel
    */

    public void SaveState(){
        Debug.Log("SaveState");
       
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerDataStorage playerData = new PlayerDataStorage();
        playerData.coins = coins;
        playerData.experience = experience;

        bf.Serialize(file,playerData);
        file.Close();
    }

    [Serializable]
    class PlayerDataStorage{
        public int coins;
        public int experience;


    }
    public void LoadState(Scene scene,LoadSceneMode mode){
        Debug.Log("LoadState");
        
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            PlayerDataStorage playerData= (PlayerDataStorage)bf.Deserialize(file);

            coins = playerData.coins;
            experience = playerData.experience;

            file.Close();

        }

        //Teleport player to spawnPoint on load
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;

    }
    /* private void Update() {
        Debug.Log(this.player.transform.position);
    } */
}
