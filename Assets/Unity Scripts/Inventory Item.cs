using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public bool stuffy = false;
    public bool key = false;
    public bool throwable = false;


    public void Disappear()
    {
        gameObject.SetActive(false);
    }

}