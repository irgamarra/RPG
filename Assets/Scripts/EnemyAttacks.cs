using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public UI ui;
    public GameObject turn;
    private Attacks attacks;
    private bool iveAttacked;

    private void Start()
    {
        attacks = GameObject.Find("Attacks").GetComponent<Attacks>();
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
            //TODO: To select a target
            GameObject target = GameObject.Find("Allies/Cube_A");

            GameObject myself = GameObject.Find("Enemies/Enemy");

            Pattern1(myself, target);

            iveAttacked = true;
        }
        if (currentTurn == ui.turn[0])
            iveAttacked = false;
    }

    //TODO: rotation
    void Pattern1(GameObject myself, GameObject target)
    {
        /*
         *   .
         * . o .
         *   .
         * */
        attacks.bulletsNumber = 4;

        //forward
        Vector3 inFront = myself.transform.position + (myself.transform.forward * 2);
        string colour = myself.GetComponent<Properties>().properties.colour;
        attacks.BouncingBall(inFront, transform.rotation, target, colour, true);

        //right
        Vector3 right = myself.transform.position + (myself.transform.right * 2);
        attacks.BouncingBall(right, transform.rotation, target, "colourless", true);

        //down
        Vector3 down = myself.transform.position + (myself.transform.forward * -2);
        attacks.BouncingBall(down, transform.rotation, target, "colourless", true);

        //left
        Vector3 left = myself.transform.position + (myself.transform.right * -2);
        attacks.BouncingBall(left, transform.rotation, target, "colourless", true);

    }
}
