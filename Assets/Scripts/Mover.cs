
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected RaycastHit2D hit;
    public Vector3 moveDelta;

    private Animator anim;

    public float xSpeed = 1.0f;
    public float ySpeed = 1.0f; //horizontal needs to be changed 0.75 but blend trees also needs to be updated


    protected virtual void Start(){

        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
 
    public virtual void moveActor(Vector3 input){
        //Reset moveDelta
        moveDelta = new Vector3(input.x * xSpeed,input.y *ySpeed,0);
        

        //Animate character according to direction
        if(moveDelta.x > 0 || moveDelta.x < 0){
            anim.SetFloat("MoveX",moveDelta.x);
            anim.SetFloat("MoveY",0f);
            anim.SetBool("Moving",true);
        }else if(moveDelta.y > 0 || moveDelta.y < 0){
            anim.SetFloat("MoveY",moveDelta.y);
            anim.SetFloat("MoveX",0f);
            anim.SetBool("Moving",true);
        }else if(moveDelta.x == 0 && moveDelta.y == 0){
            anim.SetBool("Moving",false);
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
