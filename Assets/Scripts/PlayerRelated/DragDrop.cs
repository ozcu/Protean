
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler,IDragHandler{
 
private Camera cam;
Vector3 playerPos;
Vector3 offSet;
float distance;
private SpriteRenderer sprite;
private Color color;


    private void Start()
    {
        cam = Camera.main;
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        playerPos = GameManager.instance.player.transform.position;
        offSet = (playerPos - this.transform.position);
        distance = offSet.sqrMagnitude;
        }


    

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");
    }
     public void OnDrag(PointerEventData eventData){
        Debug.Log("OnDrag");
        if(distance<0.18f){ //check if player is close to collectable item
            this.transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10.0f));
            //Change alpha in drag
            color = sprite.color;
            color.a = 0.5f;
            sprite.color = color;

        }
        
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("OnEndDrag");
        color = sprite.color;
        color.a = 1.0f;
        sprite.color = color;
        }
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");
    }

}
