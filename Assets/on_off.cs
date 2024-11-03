using UnityEngine;

public class on_off : MonoBehaviour
{
    public connection connection;
    public GameObject LED;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(connection.conn)
        LED.SetActive(true);
        else
        LED.SetActive(false);
    }
}
