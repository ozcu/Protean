
using UnityEngine;

public class Enemy : Mover
{
    public int xpAmount= 1;
    public float triggerLength = 1.0f;
    public float chaseLength = 5.0f;
    private bool isChasing;
    private bool isColliding;
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Enemy Hit Box
    private BoxCollider2D hitbox;
    public ContactFilter2D filter;
    private Collider2D[] hits = new Collider2D[10];


    protected override void Start()
    {
        base.Start();
        playerTransform = GameObject.Find("Player").transform;
        startingPosition = this.transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>(); //Boxcollider for hitbox instead of object itself
    }
    private void FixedUpdate()
    {
        //Is player in range?
        if(Vector3.Distance(playerTransform.position,startingPosition)<chaseLength){
            if(Vector3.Distance(playerTransform.position,startingPosition)<triggerLength){
                isChasing=true;
            }
            if(isChasing){
                if(!isColliding){
                    moveActor((playerTransform.position - this.transform.position).normalized);
                }else{
                    moveActor(startingPosition - this.transform.position);
                }
            }
        }else{
            moveActor(startingPosition - transform.position);
            isChasing=false;
        }
        //Check for collision
        isColliding = false;
        boxCollider.OverlapCollider(filter,hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i]==null){
                continue;
            }
           if(hits[i].tag == "Fighter" && hits[i].name == "Player"){
               isColliding = true;
           }

            //clean array
            hits[i] = null;
        }
    }


    protected override void Death(){
        Destroy(gameObject); //add animation later.
        GameManager.instance.experience += xpAmount;
        GameManager.instance.ShowText("+" + xpAmount + " XP",30,Color.blue,transform.position,Vector3.up *40,1.0f);
    }
}
