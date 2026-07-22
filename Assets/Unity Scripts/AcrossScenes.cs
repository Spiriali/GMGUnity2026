using UnityEngine;

public class AcrossScenes : MonoBehaviour
{
    public static AcrossScenes instance;
    public bool hasKey = false;
    public bool hasStuffy = false;
    public bool hasThrowable = false;
    public int health = 10;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(this.gameObject);
    }
}
