using UnityEngine;

public class CameraControl : MonoBehaviour
{
    
    public GameObject target;
    public float speed = 2f;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        transform.eulerAngles =new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        if(Input.GetMouseButton(1))
        {
            transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X")*speed);

            transform.RotateAround(target.transform.position, Vector3.right, -Input.GetAxis("Mouse Y")*speed);
            
            transform.LookAt(target.transform);
        } 

    }
}
