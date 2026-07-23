using UnityEngine;
using Yarn.Unity; 

public class ActivatingObjectPostDialogue: MonoBehaviour
{
    public GameObject targetObject;
        
    [YarnCommand("activate_object")]
    public void ActivateMyTarget()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}