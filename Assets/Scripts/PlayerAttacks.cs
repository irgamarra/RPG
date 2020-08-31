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
            //Player's attacks

            if (Input.GetButton("Fire4"))
            {
                GameObject player = GameObject.Find("Allies/Cube_A").gameObject;
                //TODO: To select a target
                GameObject target = GameObject.Find("Allies/Cube_A").gameObject;

                //TODO: to not be able to shoot more than once
                Vector3 inFront = player.transform.position + (player.transform.forward * 2);
                attacks.Ball(inFront, player.transform.rotation, target);
            }
        }
        else if(currentTurn != ui.turn[1])
            Debug.Log("Unexpected value for Current Turn");

    }
}
