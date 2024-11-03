using UnityEngine;

public class house_con : MonoBehaviour
{
    public bool conn = false;
    public connection connectio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Overlapcheck(transform.position, 30f);
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
