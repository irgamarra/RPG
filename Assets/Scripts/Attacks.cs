using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject bouncingBall;
    public GameObject piercingBall;
    public GameObject colourlessBall;
    public UI ui;
    public GameObject turn;
    private GameObject bullet;
    
    //To know how many bullets the attack can trigger
    public int bulletsNumber = -1; //We start at -1 because 0 means to end the turn
    
    //TODO: Look at diferent enemies
    //TODO: More relaviable method to get the colour (Scriptable objects)!!!!!!
    public void BouncingBall(Vector3 spawn, Quaternion rotation, GameObject target, string colour, bool multiBalls = false) //multiballs If there can be more than one ball at the same time
    {
        //If the programmer forgot to set a value to bulletsNumber 
        if (bulletsNumber == -1)
        {
            Debug.Log("Error: Bullets Numer = -1");
        }
        //IF there is not other bullet on screen and the player can shoot more...
        else if (bullet == null || multiBalls)
        {
            Debug.Log("Bullets:" + bulletsNumber);
            //To instantiate a prefab and get its RigidBody
            Rigidbody rb = InstantiateAttack(bouncingBall, spawn, rotation);

            //What colour is it
            rb.gameObject.GetComponent<Ball>().colour = colour;

            //TODO: Look at a target and to change velocity with each bounce
            rb.AddRelativeForce(0, 0, 6.0f, ForceMode.Impulse);

            bulletsNumber--;
        }
    }
    public void PiercingBall(Vector3 spawn, Quaternion rotation, GameObject target, string colour)
    {

        //If the programmer forgot to set a value to bulletsNumber 
        if (bulletsNumber == -1)
        {
            Debug.Log("Error: Bullets Numer = -1");
        }
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
    public void ColourlessBall(Vector3 spawn, Quaternion rotation, GameObject target)
    {

        //If the programmer forgot to set a value to bulletsNumber 
        if (bulletsNumber == -1)
        {
            Debug.Log("Error: Bullets Numer = -1");
        }
        else if (bullet == null)
        {
            //To instantiate a prefab and get its RigidBody
            Rigidbody rb = InstantiateAttack(colourlessBall, spawn, rotation);

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
