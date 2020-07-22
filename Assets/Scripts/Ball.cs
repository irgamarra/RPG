using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int bounces = 3;
    private int maxBounces;
    private Rigidbody rb = null;
    // Start is called before the first frame update
    void Start()
    {
        maxBounces = bounces;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounces--;
        if(bounces == 0)
        {
            DestroyBall();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Path")
        {
            DestroyBall();
        }
    }

    private void DestroyBall()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.gameObject.SetActive(false);
            bounces = maxBounces;
        }
    }
}
