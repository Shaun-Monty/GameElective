using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 3;
    public int CurrentHealth { get; private set; }


    public Stats Health;
    public Stats Bounce;
    public Stats Movement;
    


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            TakeDamage(1);

        }

    }

    





    void Awake()
    {

        CurrentHealth = maxHealth;
        



    }
    public void TakeDamage(int damage)

    {

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " Damage.");

        if (CurrentHealth <= 0)
        {

            Die();
        }

    }
        public virtual void Die()
    {

        //Die in some way
        Debug.Log(transform.name + " Died.");


    }

    











    }



