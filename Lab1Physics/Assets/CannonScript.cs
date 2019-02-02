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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && Time.time > fireDelay) {
            fireDelay = Time.time + rateOfFire;
            
            GameObject clone = Instantiate(cannonball, transform.position, transform.rotation);
            rb = clone.GetComponent<Rigidbody>();
            Vector3 direction = new Vector3(0,speed, 0);
            rb.velocity = transform.TransformDirection(direction);
            Physics.IgnoreCollision(clone.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
            Destroy(clone, 5f);
        }
    }
}
