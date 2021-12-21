
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    //TextFields
    public Text levelText,hitPointText,manaText,coinText,xpText;

    //Logic
    private string currentWeaponSelection;
    private int inventoryWeaponIndex;
    public Image currentWeaponSprite;

    public Image weaponSprite;
    public RectTransform xpBar;
    public RectTransform healthBar;
    public RectTransform manaBar;

    //Weapon Selection
    private void selectInventoryItem(bool isClicked){
        //isclicked check raycast to object and confirm

     /*    if(isClicked){
            currentWeaponSelection = gameObject.tag;
            if(gameObject.tag == "Weapon"){
                wearWeapon();
            }
        } */
    }
    public void wearWeapon(){
      //  currentWeaponSprite.sprite = GameManager.instance.inventoryWeaponSprites[inventoryWeaponIndex]; //how to define index in inventory?
    }

    //Update Character Information everytime menu is opened
    public void updateMenu(){
        //Weapon
        //weaponSprite.sprite = GameManager.instance.inventoryWeaponSprites[0];
        //Switching weapon is not implemented yet.

        //Meta
        hitPointText.text = GameManager.instance.player.hitpoint.ToString();
        manaText.text = GameManager.instance.player.mana.ToString();
        coinText.text = GameManager.instance.coins.ToString();
        xpText.text = GameManager.instance.experience.ToString();
        xpBar.localScale = new Vector3(0.5f,0,0);

       // Debug.Log(hitPointText.text);
       // Debug.Log(manaText.text);
       // Debug.Log(coinText.text);

    }

}
