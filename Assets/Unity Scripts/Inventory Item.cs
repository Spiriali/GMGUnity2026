using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public bool stuffy = false;
    public bool key = false;
    public bool throwable = false;
    public bool disappear = true;

    public void Disappear()
    {
        if (disappear)
        {
            gameObject.SetActive(false);
        }
        
    }

}