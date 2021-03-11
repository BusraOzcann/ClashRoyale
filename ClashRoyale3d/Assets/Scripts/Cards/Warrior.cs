using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    Card warrior;

    [SerializeField] private string characterName;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float energy;

    private void Start()
    { 
        warrior = new Card(characterName, characterPrefab, health, speed, damage, energy);
        

    }

}
