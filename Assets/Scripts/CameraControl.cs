using UnityEngine;


public class CameraControl : MonoBehaviour
{
    public Transform target; public float distance = 5.0f; public float xSpeed = 120.0f; public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = 3f;
    public float distanceMax = 15f;

    public float sensitivity = .5f;

    public float Pan = 1f;

    public Vector3 offset;

    private Rigidbody rigidbody;

    float x = 0.0f;
    float y = 0.0f;


    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();


        if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            offset = new Vector3(0, 0, 0);
        }

        if (target)
        {
            if (Input.GetMouseButton(2))
            {
                offset += new Vector3(-Input.GetAxis("Mouse X") * xSpeed * 0.004f * Pan * Time.deltaTime * 200, -Input.GetAxis("Mouse Y") * ySpeed * 0.004f * Pan * Time.deltaTime * 200, 0);
            }
            if (Input.GetMouseButton(1))    
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.01f * sensitivity * Time.deltaTime * 200;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f * sensitivity * Time.deltaTime * 200;
            }
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            Quaternion rotation = Quaternion.Euler(y, x, 0);

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance -= hit.distance;
            }

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position + offset;
            if (Input.GetMouseButton(1))
                transform.rotation = rotation;
            transform.position = position;


        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}