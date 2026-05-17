using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    public float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * turnSpeed * horizontalInput * Time.deltaTime);
    }
}
