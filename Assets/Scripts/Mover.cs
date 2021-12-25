
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected RaycastHit2D hit;
    protected Vector3 moveDelta;

    public Sprite Actor_right;
    public Sprite Actor_up;
    public Sprite Actor_down;

    protected float xSpeed = 1.0f;
    protected float ySpeed = 0.75f;


    protected virtual void Start(){

        boxCollider = GetComponent<BoxCollider2D>();
    }
 
    protected virtual void moveActor(Vector3 input){
        //Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed,input.y *ySpeed,0);
        

        //Swap Sprite direction
        if(moveDelta.x > 0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Actor_right;
            transform.localScale = new Vector3(1,1,0);
        }else if(moveDelta.x <0){
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = Actor_left;
            transform.localScale = new Vector3(-1,1,0);
        }else if(moveDelta.y >0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Actor_up;
        }else if(moveDelta.y <0){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Actor_down;
        }

        //Add Push Vector from Combat
        moveDelta +=pushDirection;
        //Reduce the push force according to Push Recovery Speed
        pushDirection = Vector3.Lerp(pushDirection,Vector3.zero,pushRecoverySpeed);
        

        //Control for Collision
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("Actor","Blocker"));
        if(hit.collider == null){
            //Move Player on Y
            transform.Translate(0,moveDelta.y * Time.deltaTime,0);
        }
        hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x * Time.deltaTime),LayerMask.GetMask("Actor","Blocker"));
        if(hit.collider == null){
            //Move Player on X
            transform.Translate(moveDelta.x * Time.deltaTime,0,0);
        }
    }

   



}
