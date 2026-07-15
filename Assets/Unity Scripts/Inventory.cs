using UnityEngine;

public class Inventory : MonoBehaviour
{
    //f to interact with object

    private bool pickUp;
    public bool stuffy = false;
    public bool throwable = false;
    public bool key = false;

    public GameObject stuffyImage;
    public GameObject keyImage;
    public GameObject throwableImage;
    private GameObject item;
    private InventoryItem itemScript;

    public HealthSystemAttribute healthSystem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("inventory"))
        {
           
            pickUp = true;
            item = collision.gameObject;
            itemScript = item.GetComponent<InventoryItem>();
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
        if (pickUp && Input.GetKey(KeyCode.F))
        {
            StuffyPickUp();
            ThrowablePickUp();
            KeyPickUp();
           if (itemScript.disappear) 
           {
             itemScript.Disappear();
           }
        }
        if (stuffy && Input.GetKeyDown(KeyCode.Space))
        {
            healthSystem.ModifyHealth(1);
        }
    }
    
    private void StuffyPickUp()
    {
        if (itemScript.stuffy) 
        {
            stuffy = true;
            stuffyImage.SetActive(true);
            healthSystem.stuffy = true;
        }
    }
    public void StuffyLoss()
    {
       stuffy = false;
       stuffyImage.SetActive(false);
    }
    private void KeyPickUp()
    {
        if (itemScript.key)
        {
            key = true;
            keyImage.SetActive(true);
        }
    }
    public void KeyLoss()
    {
        key = false;
        keyImage.SetActive(false);
    }
    private void ThrowablePickUp()
    {
        if (itemScript.throwable)
        {
            throwable = true;
            throwableImage.SetActive(true);
        }
    }
    public void ThrowableLoss()
    {
        throwable = false;
        throwableImage.SetActive(false);
    }
 }
