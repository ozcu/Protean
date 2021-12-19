
using UnityEngine;
using UnityEngine.UI;

public class floatingTextObj
{
   public bool active;
   public GameObject gameObj;
   public Text txt;
   public Vector3 motion;
   public float duration;
   public float lastShown;

   public void Show(){
       active = true;
       lastShown = Time.time;
       gameObj.SetActive(true);
   }
   public void Hide(){
       active = false;
       gameObj.SetActive(false);

   }
   public void UpdateFloatingText(){
       if(!active){
           return;
       }
       //If showntime is bigger than duration hide
       if(Time.time - lastShown >duration){
           Hide();
       }
       gameObj.transform.position += motion * Time.deltaTime;
   }
}
