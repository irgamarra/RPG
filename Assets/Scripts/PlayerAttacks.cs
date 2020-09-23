using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public UI ui;
    public GameObject turn;
    private Attacks attacks;
    private bool iveAttacked;

    // Start is called before the first frame update
    void Start()
    {
        Turns.StartTurn(turn, ui, 0);

        attacks = GameObject.Find("Attacks").GetComponent<Attacks>();
        iveAttacked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string currentTurn = "0";
        if (ui != null)
            currentTurn = GameObject.Find("Main Camera/UI/Canvas/Turn").GetComponent<UnityEngine.UI.Text>().text;
        else
            Debug.Log("UI not defined");

        //Enemy's turn
        if (currentTurn == ui.turn[1])
        {
            iveAttacked = false;
        }

        //Player's turn
        //TODO: Bullets not shared by everyone (Fire4 > Fire1 shouldn't be possible)
        if (currentTurn == ui.turn[0])
        {
            //Player's attacks Clock wise
            if (Input.GetButtonDown("Fire4"))
            {

                GameObject player = GameObject.Find("Allies/Cube_A").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_A").gameObject;

                //TODO: to have different attacks/to attack depending on the character
                //TODO: COLOUR NOT HARDCODED
                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                if(!iveAttacked)
                    attacks.bulletsNumber = 2;
                attacks.BouncingBall(inFront, player.transform.rotation, target, "yellow");

                iveAttacked = true;
            }

            if (Input.GetButtonDown("Fire2"))
            {

                GameObject player = GameObject.Find("Allies/Cube_B").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_B").gameObject;


                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                if (!iveAttacked)
                    attacks.bulletsNumber = 1;
                attacks.BouncingBall(inFront, player.transform.rotation, target, "red");

                iveAttacked = true;
            }

            if (Input.GetButtonDown("Fire1"))
            {

                GameObject player = GameObject.Find("Allies/Cube_C").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_C").gameObject;


                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                if (!iveAttacked)
                    attacks.bulletsNumber = 1;
                attacks.ColourlessBall(inFront, player.transform.rotation, target);

                iveAttacked = true;
            }

            if (Input.GetButtonDown("Fire3"))
            {

                GameObject player = GameObject.Find("Allies/Cube_D").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_D").gameObject;


                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                if (!iveAttacked)
                    attacks.bulletsNumber = 1;
                attacks.PiercingBall(inFront, player.transform.rotation, target, "blue");

                iveAttacked = true;
            }
        }

    }
}
