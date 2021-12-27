
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake() {
        instance=this;
    }
    #endregion

    Equipment[] currentEquipment;
    public delegate void OnEquipmentChanged(Equipment newItem,Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    Inventory inventory;
    
    void Start(){
        inventory = Inventory.instance; 

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }
    public void Equip(Equipment newItem){
        int slotIndex = (int)newItem.equipmentSlot;

        Equipment oldItem = null;

        if(currentEquipment[slotIndex] != null){
            oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add(oldItem);
        }
        //If we need to notify any methods for equipment change
        if(onEquipmentChanged != null){
            onEquipmentChanged.Invoke(newItem,oldItem);
        }
        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip(int slotIndex){
        if(currentEquipment[slotIndex] != null){
            Equipment oldItem = currentEquipment[slotIndex];
            
            if (inventory.Add(oldItem)) {
            currentEquipment[slotIndex] = null;
}

            //If we need to notify any methods for equipment change
            if(onEquipmentChanged != null){
            onEquipmentChanged.Invoke(null,oldItem);
        }
        }
        
    }





}
