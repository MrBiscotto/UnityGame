using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusTest2 : Bonus
{
    // Start is called before the first frame update
    void Start()
    {
        LifeTime = 20;
        Destroy(gameObject, LifeTime);
    }

}
