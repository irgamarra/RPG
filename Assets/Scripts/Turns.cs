using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Turns
{
    public static void StartTurn(GameObject Turn, UI ui, int who)
    {
        //who: 0 = Player's turn, 1 = Enemy's turn
        Turn.GetComponent<Text>().text = ui.turn[who];
    }
    //TODO: Options instead of "else if"
    public static void EndTurn(GameObject Turn, UI ui)
    {
        if (Turn.GetComponent<Text>().text == ui.turn[0])
            Turn.GetComponent<Text>().text = ui.turn[1];
        else if (Turn.GetComponent<Text>().text == ui.turn[1])
            Turn.GetComponent<Text>().text = ui.turn[0];
    }
    public static void Victory()
    {
        GameObject.Find("Main Camera/Victory Screen").GetComponent<Canvas>().enabled = true;
        GameObject allies = GameObject.Find("Allies");

        Allies_Movement [] am = allies.GetComponentsInChildren<Allies_Movement>();
        foreach (Allies_Movement temp in am)
            temp.enabled = false;

        GameObject.Find("Allies").GetComponent<PlayerAttacks>().enabled = false;
    }
}
