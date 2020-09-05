using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string colour = "colourless";
    public int bounces = 3;
    public int destroyedBalls = 0;
    private int maxBounces;
    private Rigidbody rb = null;
    private Material material;
    
    void Start()
    {
        maxBounces = bounces;
        rb = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material; 
    }
    
    void Update()
    {
        if (colour == "red")
        {
            material.color = Color.red;
        }
        if (colour == "yellow")
            material.color = Color.yellow;
    }

    private void OnCollisionEnter(Collision other)
    {
        string othersColour = other.gameObject.GetComponent<Properties>().properties.colour;

        CheckColour(othersColour, colour);
        
        bounces--;
        if (bounces == 0)
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

    private void CheckColour(string othersColour, string colour)
    {
        if (othersColour != colour)
        {
            if (!(colour == "colourless" || othersColour == "colourless"))
            {
                Destroy(this.gameObject);
            }
        }
    }
    /*
    private void DestroyBall()
    {
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.gameObject.SetActive(false);
            bounces = maxBounces;
        }
    }*/
}
