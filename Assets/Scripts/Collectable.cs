using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Interactable
{
    //Logic
    protected bool collected;
    public Item item;
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player"){
            OnCollect();
        }
        
    }
    protected virtual void OnCollect(){
        
        collected = true;
        Debug.Log("Picking up item " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp){
           Destroy(this.gameObject);
        }
    }
    protected virtual void OnDrop(){
        collected=false;

    }
}
