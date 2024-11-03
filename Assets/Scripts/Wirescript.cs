using UnityEngine;

public class Wirescript : MonoBehaviour
{
    public GameObject objectToSpawn;

    private void SpawnObjectAtMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(objectToSpawn, hit.point, Quaternion.identity);
        }
    }
    [SerializeField] private GameObject first;
    [SerializeField] private GameObject second;
    public GameObject wire;
    public GameObject moving_obj;
    public GameObject tower;
    public GameObject obj;

    [SerializeField] private Ray ray;
    [SerializeField] private RaycastHit hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObjectAtMousePosition();
        }

        if (Input.GetMouseButtonDown(0))
        {

            ray = GetComponentInParent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                if (!first)
                {
                    first = hit.collider.gameObject;
                }
                else
                    second = hit.collider.gameObject;
            }
        }
        if (first && second)
        {
            wire = Instantiate(wire, (first.transform.position + second.transform.position) / 2, new Quaternion(0, 0, 0, 0));
            //wire.transform.position = first.transform.position;
            wire.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            wire.transform.LookAt(second.transform.position, first.transform.position);
            wire.transform.Rotate(wire.transform.rotation.x, wire.transform.rotation.y, wire.transform.rotation.z, 0f);
            first = null;
            second = null;
        }
    }



}
