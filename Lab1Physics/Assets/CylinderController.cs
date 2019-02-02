using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
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

        
        if (Input.GetKey(KeyCode.RightArrow)) {
            adjustAngleAndDirection(transform.eulerAngles.z);
            float angle = transform.eulerAngles.z;
            rotateAngleZ(-1, angle);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            adjustAngleAndDirection(transform.eulerAngles.z);
            float angle = transform.eulerAngles.z;
            rotateAngleZ(1, angle);
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            adjustAngleAndDirection(transform.eulerAngles.x);
            float angle = transform.eulerAngles.x;
            rotateAngleX(-1, angle);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            adjustAngleAndDirection(transform.eulerAngles.x);
            float angle = transform.eulerAngles.x;
            rotateAngleX(1, angle);
        }

        //transform.rotation = rot;
    }

    void rotateAngleZ(float direction, float angle) {
        adjustAngleAndDirection(angle);
        transform.Rotate (0, 0, rotationSpeed * direction * Time.deltaTime);
    }

    void rotateAngleX(float direction, float angle) {
        adjustAngleAndDirection(angle);
        transform.Rotate (rotationSpeed * direction * Time.deltaTime, 0, 0);
    }

    void adjustAngleAndDirection(float angle) {
        if (angle > 1) {
            angle = 1;
        } if (angle < -1) {
            angle = -1;
        }
    }
}
