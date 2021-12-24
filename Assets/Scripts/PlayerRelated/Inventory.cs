using System.Collections.Generic;
using UnityEngine;

public class Inventory : Collectable
{
    #region Singleton
    public static Inventory instance;
    void Awake() {
        if(instance != null){
            Destroy(this.gameObject);
            return;
        }else if(instance ==null){
            instance = this;
        }
        
    }
    #endregion

    //An event other methods can subscribe and be fired
    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;
    
    public int invSpace = 16;
    public List<Item> items = new List<Item>();

    public bool Add(Item item){
        if(!item.isDefaulItem){
            if(items.Count >= invSpace){
                Debug.Log("Not enough room in inventory");
                return false;
            }
            items.Add(item);
            if(onInventoryChangedCallback != null){
                onInventoryChangedCallback.Invoke();
            }
            
        } 
        return true;
    }
    public void Remove(Item item){
        
        Instantiate(item.gameObject, GameManager.instance.player.transform.position + new Vector3(0.15f,0,0), Quaternion.identity);
        items.Remove(item);
        OnDrop();
        if(onInventoryChangedCallback != null){
            onInventoryChangedCallback.Invoke();
        } 
    }

   
}