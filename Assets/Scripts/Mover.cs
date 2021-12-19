using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    protected BoxCollider2D boxCollider;
    protected RaycastHit2D hit;
    protected Vector2 moveDelta;
    public Sprite Player_left;
    public Sprite Player_right;
    public Sprite Player_up;
    public Sprite Player_down;

    protected float xSpeed = 1.0f;
    protected float ySpeed = 0.75f;


    protected virtual void Start(){

        boxCollider = GetComponent<BoxCollider2D>();
    }
 
    protected virtual void UpdatePlayer(Vector3 input){
        //Reset moveDelta
    moveDelta = new Vector3(input.x * xSpeed,input.y *ySpeed,0);
    

    //Swap Sprite direction
    if(moveDelta.x > 0){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Player_right;
    }else if(moveDelta.x <0){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = Player_left;
        //transform.localScale = new Vector3(-1,1,0);
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
