
using UnityEngine;

public class LookatCursor : MonoBehaviour
{
    private Camera cam;
    Vector2 mousePosition;
    Vector2 lookDir;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    //Aim at mouse cursor
    //TODO Instead of Rotation only flip is needed toward direction.
    
    mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

    lookDir.x = mousePosition.x - GameManager.instance.player.transform.position.x;
    lookDir.y = mousePosition.y - GameManager.instance.player.transform.position.y;
    float turnAngle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
    GameManager.instance.player.transform.rotation =Quaternion.Euler(0,0,turnAngle);  
    }
}
