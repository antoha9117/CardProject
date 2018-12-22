using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObject/Card/Standart", order = 51)]
public class ScriptableObjectCard : ScriptableObject
{
    public string nameID;

    public string nameCard;

    public string description;

    public int attack;

    public int heals;

    public int manaCost;

    public Sprite artwork;

    
    public ScriptableObjectCard(string[] value, Sprite in_sprite)
    {
        this.nameID = value[0];
        this.nameCard = value[1];
        this.description = value[2];
        this.attack = Convert.ToInt32(value[3]);
        this.heals = Convert.ToInt32(value[4]);
        this.manaCost = Convert.ToInt32(value[5]);
        //this.artwork_str = value[6];
        this.artwork = in_sprite;
    }

}
