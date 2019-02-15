using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CylinderController : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    float panLimit = 0.05f;
    public GameObject player;
    Quaternion angles;
    bool headsetMode = false;
    float y, z;
    Vector3 rot;


    // Start is called before the first frame update
    void Start()
    {
        angles = InputTracking.GetLocalRotation (XRNode.CenterEye);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;

        if (Input.GetKeyDown(KeyCode.P)) {
            headsetMode = !headsetMode;
            //myAngle = player.transform.GetChild(2).gameObject.transform.eulerAngles;
            //myTransform = player.transform.GetChild(2).gameObject.transform;
        } 

        if (headsetMode) {
            rot = transform.rotation;
            rot.z = -player.transform.GetChild(0).GetChild(1).gameObject.transform.rotation.y;
            transform.rotation = rot;
            rot.x = player.transform.GetChild(0).GetChild(1).gameObject.transform.rotation.x + 0.6f;
            transform.rotation = rot;
        } else {
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
