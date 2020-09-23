using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourlessBall : MonoBehaviour
{
    public string colour = "colourless";
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Properties>().properties.colour = "colourless";
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }

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
}
