using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    protected int lifeTime;

    public int LifeTime { get => lifeTime; set => lifeTime = value; }

    protected void DropBonusMob(Enemy enemy,GameObject prefab)
    {
        Debug.Log(" PREFAB  " + prefab);
        Instantiate(prefab, new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z), Quaternion.identity);
    }

    /*protected void RandomDropBonus()
    {
        int chance = Random.Range(1, 100);

        switch (chance)
        {
            case int n when (n <= 100):

                DropBonusMob();
                break;
        }
    } 

    public void RandomBonus(Enemy ene)
    {
        enemy = ene;
        int rdn = Random.Range(1, 2);

        if(rdn == 1)
        {
            RandomDropBonus();
        }
    }*/
}
