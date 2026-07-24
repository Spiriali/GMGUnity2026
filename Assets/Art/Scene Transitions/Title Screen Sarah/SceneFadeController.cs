using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneFadeController : MonoBehaviour
{
    public Animator blackScreenAnimator;
    public string sceneToLoad = "YourSceneNameHere"; 

    
    public void TriggerScreenFade()
    {
        if (blackScreenAnimator != null)
        {
            blackScreenAnimator.SetTrigger("StartFade");
        }
    }

    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}