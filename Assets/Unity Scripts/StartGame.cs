using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject CreditScreen;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ViewCredits()
    {
        CreditScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditScreen.SetActive(false);
    }
}
