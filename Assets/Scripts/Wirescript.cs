using UnityEngine;

public class Wirescript : MonoBehaviour
{
    public GameObject first;
    public GameObject Second;

    private Ray ray;
    private RaycastHit hit;
    public GameObject wire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (!first)
                    first = hit.collider.gameObject;
                else
                    Second = hit.collider.gameObject;
            }
        }
        if (first && Second)
        {
            Instantiate(wire, (first.transform.position + Second.transform.position) / 2f, Quaternion.identity);
            first = null;
            Second = null;
        }
    }
    void OnMouseOver()
    {
        print(gameObject.name);
    }
}
