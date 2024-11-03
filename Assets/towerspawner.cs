using UnityEngine;
using UnityEngine.EventSystems;

public class towerspawner : MonoBehaviour
{
    public bool on = false;
    public money_manager money_manager;
    public GameObject obj;
    private GameObject New;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (on)
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray downRay = GetComponentInParent<Camera>().ScreenPointToRay(Input.mousePosition);

                // Cast a ray straight downwards.
                if (Physics.Raycast(downRay, out hit))
                {
                    if (hit.collider.gameObject.tag == "ground")
                    {
                        New = Instantiate(obj, hit.point, Quaternion.identity);
                        money_manager.money = money_manager.money -  10;
                        New.transform.position = hit.point;

                    }

                }
            }
    }
    public void ON()
    {
        if (on)
            on = false;
        else
        if (!on)
            on = true;
    }
}
