using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPStats

{
  
    private float BouceExp;

    public void LevelSystem()
    {
        BouceExp = 0.1f;  


    }

    public void Addexp(float amount)
    {
        BouceExp += amount;


        if(BouceExp>30f)
        {
            BouceExp = 30f; 

        }
    }
    
    public float GetBounceEXP()
    {

        return BouceExp; 

    }
}
