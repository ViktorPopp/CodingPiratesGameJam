using UnityEngine;

public class Wirescript : MonoBehaviour
{
    public GameObject first;
    public GameObject second;

    private Ray ray;
    private RaycastHit hit;
    public GameObject wire;
    public Vector3 test;
    public Vector3 middel;

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
                    second = hit.collider.gameObject;
            }
        }
        if (first && second)
        { 
            wire = Instantiate(wire, first.transform.position, new Quaternion(0,0,0,0));
            //wire.transform.position = first.transform.position;
            wire.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            wire.transform.LookAt(second.transform.position, first.transform.position);
            wire.transform.Rotate(wire.transform.rotation.x, wire.transform.rotation.y, wire.transform.rotation.z, 0f);
            first = null;
            second = null;
        }
    }

}
//(new Vector3(first.transform.position.x, first.transform.position.y, first.transform.position.z) + new Vector3(second.transform.position.x, second.transform.position.y, second.transform.position.z));