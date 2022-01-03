using UnityEngine;
using System.Collections;

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

        if(Input.GetKeyDown(KeyCode.Space)){
            if(Time.time - lastSwing > cooldown){
                lastSwing=Time.time;
                StartCoroutine(Swing());
                Debug.Log("Space key pressed");

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
    private IEnumerator Swing(){
        anim.SetBool("Attacking",true);
        yield return null;
        anim.SetBool("Attacking",false);
        yield return new WaitForSeconds(0.3f);
    }
}
