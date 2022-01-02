
using UnityEngine;

public class Weapon : Interactable
{
    //Damage Struct
    public int damagePoint= 1;
    public float pushForce = 2.0f;

    //Upgrade
    public int weaponLevel = 0;

    //Swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    private Vector3 weaponMoveDelta;

    
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
        

    }
    protected override void Update()
    {

        base.Update();
        //weaponMoveDelta = GameManager.instance.player.moveDelta; 

        if(Input.GetKeyDown(KeyCode.Space)){
            if(Time.time - lastSwing > cooldown){
                lastSwing=Time.time;
                attackRight();
                Debug.Log("space");
                /* if(weaponMoveDelta.x>0){
                    attackRight();
                }else if(weaponMoveDelta.x<0){
                    attackLeft();
                }else if(weaponMoveDelta.y >0){
                    attackUp();
                }else if(weaponMoveDelta.y <0){
                    attackDown();
                }
                 */
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter"){
            if(coll.name == "Player"){
                return;
            }
            //Create a dmg object and send it to enemy
            Damage dmg = new Damage{
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce

            };

            coll.SendMessage("ReceiveDamage",dmg);
        }
       
    }
    private void attackRight(){
        Debug.Log(anim);
        anim.SetTrigger("attack_right");
        
    }
     private void attackLeft(){
        anim.SetTrigger("attack_left");
        
    }
     private void attackUp(){
        anim.SetTrigger("attack_up");
        
    }
     private void attackDown(){
        anim.SetTrigger("attack_down");
        
    }
}
