using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject prefab;

    protected int lifeTime;
    private Transform posEnemy;

    public int LifeTime { get => lifeTime; set => lifeTime = value; }

    protected void InstantiateDrop()
    {
        Instantiate(prefab, new Vector3(posEnemy.position.x, posEnemy.position.y, posEnemy.position.z), Quaternion.identity);
    }


    protected void RandomDropBonus()
    {
        int chance = Random.Range(1, 1000);

        switch (chance)
        {
            case int tauxChance when (tauxChance <= 800):
                prefab = Resources.Load<GameObject>("Prefab/bonus1");
                InstantiateDrop();
                break;
            case int tauxChance when (tauxChance > 800):
                prefab = Resources.Load<GameObject>("Prefab/bonus2");
                InstantiateDrop();
                break;
        }
    } 

    public void RandomBonus(Transform posEne)
    {
        posEnemy = posEne;
        int rdn = Random.Range(1, 100);

        //15% de chance d'obtenir un bonus
        if(rdn <= 15)
        {
            RandomDropBonus();
        }
    }
}
