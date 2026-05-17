using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    public float bottomBound = -30;
    public float topBound = 50;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if(transform.position.z < bottomBound || transform.position.z > topBound)
        {
            Destroy(gameObject);
        }

    }
}
