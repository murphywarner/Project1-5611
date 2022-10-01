using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float mouseS = 3.0f;

    private float yRotation = 180;
    private float xRotation = 65;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float distanceFromField = 10.0f;

    private Vector3 currRotation;
    private Vector3 smoothVelocity = new Vector3(0, 0, 0);

    private float smoothTime = 0.5f;

    private Vector3 scrollWheel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseS;
            float mouseY = Input.GetAxis("Mouse Y") * mouseS;

            yRotation += mouseX;
            xRotation += mouseY;

            xRotation = Mathf.Clamp(xRotation, 10, 90);

            Vector3 nextRotation = new Vector3(xRotation, yRotation);
            currRotation = Vector3.SmoothDamp(currRotation, nextRotation, ref smoothVelocity, smoothTime);

            transform.localEulerAngles = new Vector3(xRotation, yRotation, 0);
            transform.position = target.position - transform.forward * distanceFromField;

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            distanceFromField = distanceFromField - .3f;
            transform.position = target.position - transform.forward * distanceFromField;

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            distanceFromField = distanceFromField + .3f;
            transform.position = target.position - transform.forward * distanceFromField;

        }

    }
}
/* camera movements adapted from tutorial by Deniz Simsek https://www.youtube.com/watch?v=zVX9-c_aZVg&ab_channel=DenizSimsek */