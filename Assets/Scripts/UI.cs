using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UI", menuName = "Scriptable Objects/UI", order = 1)]
public class UI : ScriptableObject
{
    public string [] turn = new string []{ "Player's turn", "Enemy's turn" };
}
