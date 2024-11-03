using Unity.Mathematics;
using UnityEngine;

public class house_con : MonoBehaviour
{
    public bool conn = false;
    private bool isOn;
    public GameObject Error;
    public connection connectio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(conn)
        Error.SetActive(false);
        if(!conn)
        Error.SetActive(true); 
            
        
        Overlapcheck(transform.position, 10f);
    }
    void Overlapcheck(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "powermain")
            {
                conn = true;
            }
            if (hitCollider.gameObject.tag == "power")
            {
                connectio = hitCollider.gameObject.GetComponent<connection>();
                if (connectio.conn)
                    conn = true;
            }

        }
    }
}
