using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera cameraObj;
    public GameObject target;
    public float speed = 2f;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        cameraObj.transform.eulerAngles =new Vector3(cameraObj.transform.eulerAngles.x, cameraObj.transform.eulerAngles.y, 0);

        if(Input.GetMouseButton(1))
        {
            cameraObj.transform.RotateAround(target.transform.position, Vector3.up, Input.GetAxis("Mouse X")*speed);

            cameraObj.transform.RotateAround(target.transform.position, Vector3.right, -Input.GetAxis("Mouse Y")*speed);
            
            transform.LookAt(target.transform);
        } 

    }
}
