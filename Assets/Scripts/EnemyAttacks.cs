using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public UI ui;
    public GameObject turn;
    public GameObject path;
    private Attacks attacks;
    private bool iveAttacked;

    private void Start()
    {
        attacks = GameObject.Find("Attacks").GetComponent<Attacks>();
        path = GameObject.Find("Path/Spots");
        iveAttacked = false;
    }
    void Update()
    {
        string currentTurn = "0";
        if (ui != null)
            currentTurn = GameObject.Find("Main Camera/UI/Canvas/Turn").GetComponent<UnityEngine.UI.Text>().text;
        else
            Debug.Log("UI not defined");

        //Enemy's turn
        if (currentTurn == ui.turn[1] && !iveAttacked)
        {
            GameObject myself = GameObject.Find("Enemies/Enemy");

            StartCoroutine(Pattern1and2(myself, 1));

            iveAttacked = true;
        }
        if (currentTurn == ui.turn[0])
            iveAttacked = false;
    }

    IEnumerator Pattern1and2 (GameObject myself, int delay)
    {
        attacks.bulletsNumber = 8;
        Pattern1(myself);
        yield return new WaitForSeconds(delay);
        Pattern2(myself);
    }
    //TODO: Better logic: An array and a for
    void Pattern1(GameObject myself)
    {
        /*
         *   .
         * . o .
         *   .
         * */
        string spot1 = "0";
        string spot2 = "5";
        string spot3 = "10";
        string spot4 = "15";

        if (attacks.bulletsNumber < 4)
            attacks.bulletsNumber = 4;

        //forward
        Vector3 spawnInFront = myself.transform.position + (myself.transform.forward * 2);
        string colour = myself.GetComponent<Properties>().properties.colour;
        Quaternion rotationForward = Quaternion.LookRotation(path.transform.Find(spot1).transform.position);
        attacks.BouncingBall(spawnInFront, rotationForward, colour, true);

        //right
        Vector3 spawnRight = myself.transform.position + (myself.transform.right * 2);
        Quaternion rotationRight = Quaternion.LookRotation(path.transform.Find(spot2).transform.position);
        attacks.BouncingBall(spawnRight, rotationRight, "colourless", true);

        //down
        Vector3 SpawnDown = myself.transform.position + (myself.transform.forward * -2);
        Quaternion rotationDown = Quaternion.LookRotation(path.transform.Find(spot3).transform.position);
        attacks.BouncingBall(SpawnDown, rotationDown, "colourless", true);

        //left
        Vector3 SpawnLeft = myself.transform.position + (myself.transform.right * -2);
        Quaternion rotationLeft = Quaternion.LookRotation(path.transform.Find(spot4).transform.position);
        attacks.BouncingBall(SpawnLeft, rotationLeft, "colourless", true);
        
    }

    void Pattern2(GameObject myself)
    {

        /*
         * .   .
         *   o 
         * .   .
         * */
        string spot1 = "3";
        string spot2 = "7";
        string spot3 = "12";
        string spot4 = "17";

        if (attacks.bulletsNumber < 4)
            attacks.bulletsNumber = 4;

        //forward
        Vector3 spawnNE = myself.transform.position + (myself.transform.forward * 2) + (myself.transform.right * 2);
        string colour = myself.GetComponent<Properties>().properties.colour;
        Quaternion rotationForward = Quaternion.LookRotation(path.transform.Find(spot1).transform.position);
        attacks.BouncingBall(spawnNE, rotationForward, colour, true);

        //right
        Vector3 spawnSE = myself.transform.position + (myself.transform.forward * -2) + (myself.transform.right * 2);
        Quaternion rotationRight = Quaternion.LookRotation(path.transform.Find(spot2).transform.position);
        attacks.BouncingBall(spawnSE, rotationRight, "colourless", true);

        //down
        Vector3 spawnSW = myself.transform.position + (myself.transform.forward * -2) + (myself.transform.right * -2);
        Quaternion rotationDown = Quaternion.LookRotation(path.transform.Find(spot3).transform.position);
        attacks.BouncingBall(spawnSW, rotationDown, "colourless", true);

        //left
        Vector3 spawnNW = myself.transform.position + (myself.transform.forward * 2) + (myself.transform.right * -2);

        Quaternion rotationLeft = Quaternion.LookRotation(path.transform.Find(spot4).transform.position);
        attacks.BouncingBall(spawnNW, rotationLeft, "colourless", true);
    }
}
