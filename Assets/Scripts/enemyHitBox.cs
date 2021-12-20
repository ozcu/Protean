using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHitBox : Interactable
{
    //Damage
    public int damage;
    public float pushForce;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter" && coll.name =="Player"){
            //Create a dmg object and send it to enemy
            Damage dmg = new Damage{
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce

            };
            coll.SendMessage("ReceiveDamage",dmg);
        }
    }
}
