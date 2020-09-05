using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject bouncingBall;
    public GameObject piercingBall;
    public UI ui;
    public GameObject turn;
    private GameObject bullet;
    
    //To know how many bullets the attack can trigger
    private int bulletsNumber = -1; //We start at -1 because 0 means to end the turn
    
    //TODO: Look at diferent enemies
    //TODO: More relaviable method to get the colour (Scriptable objects)!!!!!!
    public void BouncingBall(Vector3 spawn, Quaternion rotation, GameObject target, int bullets, string colour)
    {
        if (bulletsNumber == -1)
            bulletsNumber = bullets;
        //IF there is not other bullets on screen and the player can shoot more...
        else if (bullet == null)
        {
            //To instantiate a prefab and get its RigidBody
            Rigidbody rb = InstantiateAttack(bouncingBall, spawn, rotation);

            //What colour is it
            rb.gameObject.GetComponent<Ball>().colour = colour;

            //TODO: Look at a target and to change velocity with each bounce
            rb.AddRelativeForce(0, 0, 6.0f, ForceMode.Impulse);

            bulletsNumber--;
        }
    }
    public void PiercingBall(Vector3 spawn, Quaternion rotation, GameObject target, int bullets, string colour)
    {
        if (bulletsNumber == -1)
            bulletsNumber = bullets;
        else if(bullet == null)
        {
            //To instantiate a prefab and get its RigidBody
            Rigidbody rb = InstantiateAttack(piercingBall, spawn, rotation);

            //What colour is it
            rb.gameObject.GetComponent<PiercingBall>().colour = colour;

            //TODO: Look at a target and to change velocity with each bounce
            rb.AddRelativeForce(0, 0, 6.0f, ForceMode.Impulse);

            bulletsNumber--;
        }

    }

    private Rigidbody InstantiateAttack(GameObject attack, Vector3 spawn, Quaternion rotation)
    {
        //Where to spawn
        bullet = Instantiate(attack, spawn, rotation) as GameObject;
        bullet.transform.parent = GameObject.Find("Attacks").transform;
        //How to move
        bullet.SetActive(true);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        return rb;
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
