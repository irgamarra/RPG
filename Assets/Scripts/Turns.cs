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
}
