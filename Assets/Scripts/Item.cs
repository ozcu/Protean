
using UnityEngine;

 [CreateAssetMenu(fileName ="New Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaulItem = false;
    public GameObject gameObject; //to instantiate gameobj in game

    public virtual void Use(){

        Debug.Log("Using "+name);
    }
    public void RemoveFromInventory(){
        Inventory.instance.Remove(this);
    }

}
