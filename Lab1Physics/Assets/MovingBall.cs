using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{

    public float speed = 3f;
    public float rollSpeed = 3f;
    public float max = 4f;
    public float min = -4f;
    Rigidbody rb;
    Vector3 move;
    bool directionRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector3(speed*Time.deltaTime*rollSpeed, 0, 0);

        if (directionRight) {
            rb.AddForce(move);
        } else {
            rb.AddForce(-move);
        }

        if (transform.position.x >= max) {
            directionRight = false;
        }

        if (transform.position.x < min) {
            directionRight = true;
        }

        if (Input.GetKey(KeyCode.Q)) {
            speed--;
            
        } else if (Input.GetKey(KeyCode.W)) {
            speed++;
        }
        adjustSpeed();
        
    }

    void adjustSpeed() {
        if (speed < 0) {
            speed = 0;
        } else if (speed > 10) {
            speed = 10;
        }
    }
}
