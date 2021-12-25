

using UnityEngine;


public class Player : Mover
{
    
    private SpriteRenderer spriteRenderer;
    //private Camera cam;
    //Vector2 mousePosition;
    //Vector2 lookDir;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //cam = Camera.main;
    }
    private void FixedUpdate(){

    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");
    moveActor(new Vector3(x,y,0));

    //Aim at mouse cursor
  /*   mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

    lookDir.x = mousePosition.x - this.transform.position.x;
    lookDir.y = mousePosition.y - this.transform.position.y;
    float turnAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
    this.transform.rotation =Quaternion.Euler(0,0,turnAngle); */
    
    } 

     
}
