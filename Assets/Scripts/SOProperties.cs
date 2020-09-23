using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Scriptable Objects/Unit", order = 1)]
public class SOProperties : ScriptableObject
{
    public string unitName;
    public string colour;
    public bool ally;
    public bool enemy;
    public int hp;
}
