using UnityEngine;

public class Bonus : MonoBehaviour
{
    protected int lifeTime;

    public int LifeTime { get => lifeTime; set => lifeTime = value; }


    protected void RandomDropBonus(Transform posEnemy)
    {
        int chance = Random.Range(1, 1000);

        Debug.Log("CHANCE ENTRE LES 2 BONUS " + chance);

        switch (chance)
        {
            case int tauxChance when (tauxChance <= 600):
                Instantiate(Resources.Load("Prefab/bonus1",typeof(BonusHealth)), new Vector3(posEnemy.position.x, posEnemy.position.y, posEnemy.position.z), Quaternion.identity);
                break;
            case int tauxChance when (tauxChance <= 1000 && tauxChance >600):
                Instantiate(Resources.Load("Prefab/bonus2", typeof(BonusTest2)), new Vector3(posEnemy.position.x, posEnemy.position.y, posEnemy.position.z), Quaternion.identity);
                break;
        }
    } 

    public void RandomBonus(Transform posEnemy)
    {
        int rdn = Random.Range(1, 100);
        Debug.Log("RANDOM POUR DROP " + rdn);

        //30% de chance d'obtenir un bonus
        if(rdn <= 15)
        {
            RandomDropBonus(posEnemy);
        }
    }
}
