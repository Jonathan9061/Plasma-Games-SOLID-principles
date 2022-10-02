using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float CurrentHealth;
    bool dead;

    void Start()
    {
        CurrentHealth = health; 
    }
    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            dead = true;
        }
    }
}
