using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public GameObject cannonball;
    Rigidbody rb;
    public float rateOfFire;
    float fireDelay;
    public float speed;
    bool headsetMode = false;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P)) {
            headsetMode = !headsetMode;
            //myAngle = player.transform.GetChild(2).gameObject.transform.eulerAngles;
            //myTransform = player.transform.GetChild(2).gameObject.transform;
        } 

        if (Input.GetKey(KeyCode.F) && Time.time > fireDelay && !headsetMode) {
            fireBall();
            
        } else if (Time.time > fireDelay && headsetMode){
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f) {
                fireBall();
            }
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            speed += 2;
            
        } else if (Input.GetKeyDown(KeyCode.H)) {
            speed -= 2;
        }

        adjustSpeed();
    }

    void fireBall() {
        fireDelay = Time.time + rateOfFire;
            
            GameObject clone = Instantiate(cannonball, transform.position, transform.rotation);

            rb = clone.GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(0,speed, 0);
            rb.velocity = transform.TransformDirection(direction);
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
    }

    void adjustSpeed() {
        if (speed > 45) {
            speed = 45;
        } else if (speed < 10) {
            speed = 10;
        }
    }
}
