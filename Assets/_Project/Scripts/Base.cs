using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Health
{
    public GameOverScreen GameOverScreen
        
        ;


    public override void Die()
    {
        GameOverScreen.Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
