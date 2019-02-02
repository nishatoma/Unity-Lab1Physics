using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Mouse start position, end position and the direcrtion of the mouse
    Vector2 startPos, endPos, direction;
    // This is to calculate the time mouse was dragged in order to calculate the force of the ball.
    float mouseHeldStartTime, mouseHeldFinishTime, timeInterval;

    // Access from editor but not other scripts!
    [SerializeField]
    float throwForceInX = 1f;

    [SerializeField]
    float throwForceInY = 1f;

    [SerializeField]
    float throwForceInZ = 50f;

    Rigidbody rigidBody;
    public GameObject gameObject;

    // Get the sphere object
    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // The update method is called once per frame;
    void Update() {
        // if You hold down the mouse
        if (Input.GetMouseButton(0)) {
            mouseHeldStartTime = Time.time;
            startPos = Input.mousePosition;
        }

        // When the mouse is released
        if (Input.GetMouseButtonUp(0)) {
            mouseHeldFinishTime = Time.time;

            timeInterval = mouseHeldFinishTime - mouseHeldStartTime;

            endPos = Input.mousePosition;

            direction = startPos - endPos;

            rigidBody.isKinematic = false;
            rigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            rigidBody.AddForce(-direction.x*throwForceInX, -direction.y*throwForceInY, throwForceInZ/timeInterval);
        } 
    }

    // Destroy the ball on collision
    void OnCollisionStay (Collision col)
    {
        //Destroy(gameObject, 2);   
    }



}
