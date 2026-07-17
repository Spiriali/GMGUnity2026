using UnityEngine;

public class Inventory : MonoBehaviour
{
    //f to interact with object

    private bool pickUp;
    public bool stuffy = false;
    public bool throwable = false;
    public bool key = false;
    private bool canHeal = true;
    private bool stuffySelected = false;
    private bool keySelected = false;
    private bool throwableSelected = false;

    public GameObject stuffyImage;
    public GameObject keyImage;
    public GameObject throwableImage;
    public GameObject stuffySelect;
    public GameObject keySelect;
    public GameObject throwableSelect;
    private GameObject item;
    private InventoryItem itemScript;

    public HealthSystemAttribute healthSystem;
    public GameObject stuffyObject;
    public TopDownShootProjectile shootScript;
    public Move moveScript;
    public float frozenTime = 1f;

    private void Start()
    {
        shootScript = GetComponent<TopDownShootProjectile>();
        moveScript = GetComponent<Move>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("inventory"))
        {
           
            pickUp = true;
            item = collision.gameObject;
            itemScript = item.GetComponent<InventoryItem>();
        }
        if (collision.CompareTag("Closet"))
        {
            if (stuffy) 
            {
                //stuffy disappears from inventory
                // plyer no longer has stuffy in inventory logic
                StuffyLoss();
                //sprite of stuffy appears in the enviornment outside of the closet
                Instantiate(stuffyObject, collision.gameObject.GetComponent<Closet>().spawnLocation, Quaternion.identity);
            }
        }
        if (collision.CompareTag("Locked"))
        {
            if (key)
            {
                collision.gameObject.SetActive(false);
                KeyLoss();
            }
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
        if (stuffy && Input.GetKeyDown(KeyCode.E))
        {
            if (canHeal && stuffySelected)
            {
                healthSystem.ModifyHealth(1);
                canHeal = false;
                moveScript.enabled = false;
                shootScript.enabled = false;
                Invoke(nameof(EnableMoveShoot), frozenTime);
            }
            if (keySelected)
            {

            }
            if (throwableSelected)
            {

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) 
        {
            stuffySelected = !stuffySelected;
            keySelected = false;
            throwableSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            keySelected = !keySelected;
            stuffySelected = false;
            throwableSelected = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            throwableSelected = !throwableSelected;
            stuffySelected = false;
            keySelected = false;
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
       healthSystem.stuffy = false;
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

    private void EnableMoveShoot()
    {
        moveScript.enabled = true;
        shootScript.enabled = true;
        canHeal = true;
    }
 }
