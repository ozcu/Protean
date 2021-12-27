using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Equipment",menuName ="Inventory/Equipment")]
public class Equipment : Item
{
    public int damageModifier;
    public float pushForce;
    public int level;
     //Swing
    private Animator anim;
    private float cooldown;
    private float lastSwing;
    public int armorModifier;
    public EquipmentSlot equipmentSlot;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
        //remove from inventory
    }
}

public enum EquipmentSlot {Weapon, Head,Chest,Legs,Feet,Shield}
