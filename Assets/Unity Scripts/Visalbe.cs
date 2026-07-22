using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public GameObject prefabToToggle;

    void Update()
    {
        // Toggle visibility when the 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check the current active state and reverse it
            bool isVisible = prefabToToggle.activeSelf;
            prefabToToggle.SetActive(!isVisible);
        }
    }
}