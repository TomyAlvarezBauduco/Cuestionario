using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class CardInfo
{ 
    public string cardName = "";
    public Sprite cardSprite = null;
    public float currentHealth = 100;
    public float totalHealth = 100;
    public int attackDamage = 50;

    public Vector2 cardPosition;
    public Quaternion cardRotation;
    public Color cardColor;
}
