using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public UI ui;
    public GameObject turn;
    private Attacks attacks;

    private void Start()
    {
        attacks = GameObject.Find("Attacks").GetComponent<Attacks>();
    }
    void Update()
    {
        string currentTurn = "0";
        if (ui != null)
            currentTurn = GameObject.Find("Main Camera/UI/Canvas/Turn").GetComponent<UnityEngine.UI.Text>().text;
        else
            Debug.Log("UI not defined");

        //Enemy's turn
        if (currentTurn == ui.turn[1])
        {
            //TODO: To select a target
            GameObject target = GameObject.Find("Allies/Cube_A");

            GameObject enemy = GameObject.Find("Enemies/Enemy");
            Vector3 inFront = enemy.transform.position + (enemy.transform.forward * 2);
            attacks.Ball(inFront, enemy.transform.rotation, target);
        }
    }
}
