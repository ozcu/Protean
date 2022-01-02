
using UnityEngine;

public class CursorPointer : MonoBehaviour
{
    public Texture2D cursorDefault;
    //public Texture2D cursorPickaxe;


    void Start()
    {
        Cursor.SetCursor(cursorDefault,Vector3.zero,CursorMode.ForceSoftware);
    }

    //In case cursor to change use below.
    // private void OnMouseEnter() {
    //     Cursor.SetCursor(cursorPickaxe,Vector3.zero,CursorMode.ForceSoftware);
    // }
}
