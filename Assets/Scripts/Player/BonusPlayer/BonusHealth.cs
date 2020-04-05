using UnityEngine;

public class BonusHealth : Bonus
{
    public void Start()
    {
        LifeTime = 10;
        Destroy(gameObject, LifeTime);
    }
}
