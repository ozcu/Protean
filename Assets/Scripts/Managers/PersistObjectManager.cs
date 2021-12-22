
using UnityEngine;

public class PersistObjectManager : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
