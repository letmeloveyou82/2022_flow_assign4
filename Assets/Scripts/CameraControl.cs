using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform root;

    float mouseX;

    public float stomachOffset;

    public ConfigurableJoint hipJoint, stomachJoint;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void FixedUpdate()
    {
        CamControl();
    }

    void CamControl()
    {
        if (Input.GetMouseButton(0))
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;

            Quaternion rootRotation = Quaternion.Euler(0, mouseX, 0);

            root.rotation = rootRotation;

            hipJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
        }
        
    }
}
