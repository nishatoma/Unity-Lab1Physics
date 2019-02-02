using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    public Text textUI;
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textUI.text = "Score: " + score;
    }

    void OnCollisionEnter(Collision col) {
        if (!col.gameObject.tag.Equals("enemy")) {
            score++;
            Destroy(gameObject, 1f);
        }
    }
}