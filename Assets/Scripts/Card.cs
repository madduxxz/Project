using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite characterPP;
    public GameObject playerCharacter;

    public Material playerMat;
    public int stamina;
    public int attack;
    public int health;    
}
