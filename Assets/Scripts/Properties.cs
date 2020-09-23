using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    public SOProperties properties;
    [SerializeField]
    public int maxHP = 0;

    private int currentHP = 0;

    public event Action<float> OnHealthPctChanged = delegate { };
    void Start()
    {
        //TODO: Scriptable Object to be a Color instead of a String
        Color color = this.GetComponent<Renderer>().material.color;
        if(color == Color.red)
        {
            properties.colour = "red";
        }

        maxHP = properties.hp;
        currentHP = maxHP;
    }

    public void ModifyHP(int amount)
    {
        currentHP += amount;

        float currentHPPct = (float)currentHP / (float)maxHP;
        OnHealthPctChanged(currentHPPct);

    }

    public void OnCollisionEnter(Collision collision)
    {
        ModifyHP(-10);
    }
}
