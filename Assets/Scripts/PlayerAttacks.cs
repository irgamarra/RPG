using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public UI ui;
    public GameObject turn;
    private Attacks attacks;

    // Start is called before the first frame update
    void Start()
    {
        Turns.StartTurn(turn, ui, 0);

        attacks = GameObject.Find("Attacks").GetComponent<Attacks>();
    }

    // Update is called once per frame
    void Update()
    {
        string currentTurn = "0";
        if (ui != null)
            currentTurn = GameObject.Find("Main Camera/UI/Canvas/Turn").GetComponent<UnityEngine.UI.Text>().text;
        else
            Debug.Log("UI not defined");

        //Player's turn
        if (currentTurn == ui.turn[0])
        {
            //Player's attacks Clock wise

            if (Input.GetButton("Fire4"))
            {
                GameObject player = GameObject.Find("Allies/Cube_A").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_A").gameObject;

                //TODO: to have different attacks/to attack depending on the character
                //TODO: COLOUR NOT HARDCODED
                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                attacks.BouncingBall(inFront, player.transform.rotation, target, 2, "yellow");
            }

            if (Input.GetButton("Fire2"))
            {
                GameObject player = GameObject.Find("Allies/Cube_B").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_B").gameObject;

                
                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                attacks.BouncingBall(inFront, player.transform.rotation, target, 1, "red");
            }

            if (Input.GetButton("Fire1"))
            {
                GameObject player = GameObject.Find("Allies/Cube_C").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_C").gameObject;

                
                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                attacks.PiercingBall(inFront, player.transform.rotation, target, 1, "colourless");
            }

            if (Input.GetButton("Fire3"))
            {
                GameObject player = GameObject.Find("Allies/Cube_D").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_D").gameObject;

                
                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                attacks.PiercingBall(inFront, player.transform.rotation, target,1, "blue");
            }
        }
        else if(currentTurn != ui.turn[1])
            Debug.Log("Unexpected value for Current Turn");

    }
}
