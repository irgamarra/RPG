using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int bounces = 3;
    public int destroyedBalls = 0;
    private int maxBounces;
    private Rigidbody rb = null;
    
    void Start()
    {
        maxBounces = bounces;
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounces--;
        if(bounces == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Path")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        
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
