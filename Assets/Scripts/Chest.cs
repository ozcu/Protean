using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    protected override void OnCollide(Collider2D coll)
    {
       Debug.Log("Grant Coins!");
    }
}
