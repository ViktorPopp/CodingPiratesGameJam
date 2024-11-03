using UnityEngine;
using UnityEngine.EventSystems;

public class towerspawner : MonoBehaviour
{
    public GameObject obj;
    private GameObject New;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray downRay = GetComponentInParent<Camera>().ScreenPointToRay(Input.mousePosition);

            // Cast a ray straight downwards.
            if (Physics.Raycast(downRay, out hit))
            {
                New = Instantiate(obj, hit.point, Quaternion.identity);
        
                New.transform.position = hit.point;
            }
        }
    }
}
