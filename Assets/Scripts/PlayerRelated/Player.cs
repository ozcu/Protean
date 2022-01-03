

using UnityEngine;


public class Player : Mover
{
    
    private void FixedUpdate(){

    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");
    moveActor(new Vector3(x,y,0));

    } 

}
