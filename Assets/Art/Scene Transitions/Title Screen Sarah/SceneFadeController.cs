using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading scenes

public class SceneFadeController : MonoBehaviour
{
    public Animator blackScreenAnimator;
    public string sceneToLoad = "YourSceneNameHere"; // Type your exact scene name here

    // Triggers the black screen fade (Already using this)
    public void TriggerScreenFade()
    {
        if (blackScreenAnimator != null)
        {
            blackScreenAnimator.SetTrigger("StartFade");
        }
    }

    // NEW: Call this at the end of the fade animation
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}