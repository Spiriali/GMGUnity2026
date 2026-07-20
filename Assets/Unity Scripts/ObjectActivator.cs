using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] GameObject obj;
    private bool triggered = false;
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            obj.SetActive(true);
            triggered = true;
        }
    }
}
