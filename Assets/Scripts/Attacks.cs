using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TODO: Look at diferent enemies
    public static void Ball(Vector3 spawn)
    {
        GameObject ball = GameObject.Find("Allies/Attacks/Ball");
        GameObject enemy = GameObject.Find("Enemies/Enemy");

        //Where to spawn
        ball.transform.position = spawn;
        ball.transform.LookAt(enemy.transform);

        //How to move
        ball.SetActive(true);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        
        rb.AddRelativeForce(0, 0, 6.0f, ForceMode.Impulse);
    }
}
