using UnityEngine;

public class Inventory : MonoBehaviour
{
    //f to interact with object

    private bool pickUp;
    public bool stuffy;

    private GameObject item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("inventory"))
        {
           
            pickUp = true;
            item = collision.gameObject;
        }
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("inventory"))
        {
            pickUp = false;
            
        }
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            
        }
        if (pickUp && Input.GetKey(KeyCode.F))
        {
            
            item.GetComponent<InventoryItem>().Disappear();
        }
    }
    
}
