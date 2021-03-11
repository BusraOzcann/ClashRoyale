using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string characterName;
    public GameObject characterPrefab;
    public float health;
    public float speed;
    public float damage;
    public float energy;

    public Card(string characterName, GameObject characterPrefab, float health, float speed, float damage, float energy)
    {
        this.characterName = characterName;
        this.characterPrefab = characterPrefab;
        this.health = health;
        this.speed = speed;
        this.damage = damage;
    }
    

}
