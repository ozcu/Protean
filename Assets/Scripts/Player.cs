using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private RaycastHit2D hit;
    private Vector2 moveDelta;
    public Sprite Player_left;
    public Sprite Player_right;
    public Sprite Player_up;
    public Sprite Player_down;

    private void Start(){

        boxCollider = GetComponent<BoxCollider2D>();
    }

  private void FixedUpdate() {
      

    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");

    //Reset moveDelta
    moveDelta = new Vector2(x,y);
    

    //Swap Sprite direction
    if(moveDelta.x > 0){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Player_right;
    }else if(moveDelta.x <0){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Player_left;
    }else if(moveDelta.y >0){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Player_up;
    }else if(moveDelta.y <0){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Player_down;
    }

    

    //Control for Collision
    hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("Actor","Blocker"));
    if(hit.collider == null){
        //Move Player
        transform.Translate(0,moveDelta.y * Time.deltaTime,0);
    }
     hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x * Time.deltaTime),LayerMask.GetMask("Actor","Blocker"));
    if(hit.collider == null){
        //Move Player
        transform.Translate(moveDelta.x * Time.deltaTime,0,0);
    }

}


}
