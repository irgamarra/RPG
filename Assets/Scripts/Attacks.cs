using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject ballGO;
    public UI ui;
    public GameObject turn;
    private GameObject bullet;

    //To know how many bullets the player triggered
    private bool bulletsTriggered = false;
    //To know how many bullets the attack can trigger
    private int bulletsNumber = -1; //We start at -1 to forbid the player to shoot at 0
    
    //TODO: Look at diferent enemies
    public void Ball(Vector3 spawn, Quaternion rotation, GameObject target)
    {
        if (bulletsNumber == -1)
            bulletsNumber = 1;
        //IF there is not other bullets and the player can shoot more...
        if (bullet == null && bulletsNumber > 0)
        {
            //Where to spawn
            bullet = Instantiate(ballGO, spawn, rotation) as GameObject;
            bullet.transform.parent = this.transform;

            //How to move
            bullet.SetActive(true);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            //TODO: Look at a target(?)
            rb.AddRelativeForce(0, 0, 6.0f, ForceMode.Impulse);

            bulletsNumber--;
        }
    }
    public void Update()
    {
        if (bullet == null && bulletsNumber == 0)
        {
            bulletsNumber = -1;
            Turns.EndTurn(turn, ui);
        }
    }
}
