using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    float panLimit = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;

        if (Input.GetKey(KeyCode.RightArrow) && rot.y < panLimit) {
            rot.y -= rotationSpeed;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            rot.y += rotationSpeed;
        }
        rot.y = Mathf.Clamp(rot.y, -45, 45);
        rot = Quaternion.Euler(0, rot.y, 0);
        transform.rotation = rot;
    }
}
