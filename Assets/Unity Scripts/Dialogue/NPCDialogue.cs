using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class NPCDialogue : MonoBehaviour
{
    public string dialogueNode;
    public string levelLoad;

    [YarnCommand("nextscene")]
    public void NextScene()
    {
        if (levelLoad != null)
        {
            SceneManager.LoadScene(levelLoad, LoadSceneMode.Single);
        }
    }
}
