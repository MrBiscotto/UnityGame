using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : Bonus
{
    public GameObject prefabHealth;
    // Start is called before the first frame update
    void Start()
    {
        LifeTime = 10;
    }

    public void DropBonus(Enemy enemy)
    {
        Debug.Log("PASSAGE HEALTH " + prefabHealth);
        this.DropBonusMob(enemy,prefabHealth);
    }

}
