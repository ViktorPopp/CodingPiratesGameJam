using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isOccupied;
    public Color green;
    public Color red;
    private SpriteRenderer renderer;

    void Start()
    {
        renderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isOccupied == true)
            renderer.color = red;
        else
            renderer.color = green;
    }
}
