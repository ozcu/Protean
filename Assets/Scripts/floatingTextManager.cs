using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;
    private List<floatingTextObj> floatingTexts = new List<floatingTextObj>();

    private void Update() {
        foreach(floatingTextObj txt in floatingTexts){
            txt.UpdateFloatingText();
        }
    }
    public void Show(string msg,int fontSize,Color color,Vector3 position,Vector3 motion,float duration){
        floatingTextObj floatingTextObj = GetFloatingText();
        floatingTextObj.txt.text = msg;
        floatingTextObj.txt.fontSize = fontSize;
        floatingTextObj.txt.color = color;
        floatingTextObj.gameObj.transform.position = Camera.main.WorldToScreenPoint(position);
         floatingTextObj.motion = motion;
        floatingTextObj.duration = duration;

        floatingTextObj.Show();

    }

    private floatingTextObj GetFloatingText(){
        floatingTextObj txt =floatingTexts.Find(t=>!t.active);

        if(txt==null){
            txt =new floatingTextObj();
            txt.gameObj =Instantiate(textPrefab);
            txt.gameObj.transform.SetParent(textContainer.transform);
            txt.txt = txt.gameObj.GetComponent<Text>();
        
            floatingTexts.Add(txt);
        }
        

        return txt;
    }
}
