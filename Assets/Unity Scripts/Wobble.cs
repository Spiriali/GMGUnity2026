using UnityEngine;

public class Wobble : MonoBehaviour
{
    Vector2 floatY;
    float originalY;

    public float floatStrength;

    void Start()
    {
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        floatY = transform.position;
        floatY.y = (Mathf.Sin(Time.time) * floatStrength) + originalY;
        transform.position = floatY;
    }
}
