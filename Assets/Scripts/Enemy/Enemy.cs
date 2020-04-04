using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static int score = 0;
    protected GameObject _text;

    [Header("Enemy Variables")]
    public int _health;
    public int _damage;
    public float _speed = 6f;
    public float _rotate = 4.5f;
    public float _distance = 0;

    private static bool firstWalky = false;
    private static bool firstWhelly = false;
    private static bool firstBrainly = false;

    private ScorePlayer scoreP = new ScorePlayer();
    private Bonus bonus = new Bonus();

    public Transform _target = null;
    protected Vector3 direction = Vector3.forward;
    protected Quaternion newRotation = Quaternion.identity;

    protected virtual void Start()
    {
        _text = GameObject.FindGameObjectWithTag("Score");
    }

    #region Getters & Setters
    public int Health
    {
        get
        {
            return this._health;
        }
        set
        {
            this._health = value;
        }
    }

    public int Damage
    {
        get
        {
            return this._damage;
        }
        set
        {
            this._damage = value;
        }
    }

    public float Distance
    {
        get
        {
            return this._distance;
        }
        set
        {
            this._distance = value;
        }
    }
    #endregion

    /// <summary>
    /// If bullet touch, health -5
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            _health -= 5;
            if (_health <= 0)
            {
                if (this.gameObject.tag == "Walky")
                {
                    scoreP.NbWalkyKill += 1;
                    score += 70;
                }
                else if (this.gameObject.tag == "Wheely")
                {
                    scoreP.NbWhellyKill += 1;
                    score += 50;    
                }
                else if (this.gameObject.tag == "Brainly")
                {
                    score += 200;
                }

                RandomBonus();
                Destroy(gameObject, 0);
                scoreP.NbEnemy -= 1;
            }
        }
    }

 
    /// <summary>
    /// Move enemy
    /// </summary>
    /// <param name="distance"></param>
    protected void Move(float distance)
    {
        //Permet de mettre une distance entre le mob et le joueur
        Vector3 _displacementFromTarget = _target.position - transform.position;
        Vector3 _directionToTarget = _displacementFromTarget.normalized;

        // on normalize le resultat avant de s'en servir, puisque que ici seule la direction du vector nous interesse
        direction = (_target.position - transform.position).normalized;

        float posX = _target.position.x - transform.position.x;
        float posZ = _target.position.z - transform.position.z;

        if (Mathf.Abs(posX) >= distance || Mathf.Abs(posZ) >= distance)
        {
            // on update la position
            transform.position += direction *_speed *Time.deltaTime ;
        }
    }

    /// <summary>
    /// Orient 
    /// </summary>
    protected void Orient()
    {
        // on oriente notre object dans la direction ou l on va
        newRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * _rotate);
    }

    #region BonusDropMobs
    /// <summary>
    /// Chance drop for each bonus
    /// </summary>
    private void RandomDropBonus()
    {
        int chance = Random.Range(1, 100);

        switch (chance)
        {
            case int n when (n <= 100):
                BonusHealth bonus = new BonusHealth();
                bonus.DropBonus(this);
                break;
        }
    }

    /// <summary>
    /// Drop chance bonus 
    /// </summary>
    /// <param name="ene"></param>
    private void RandomBonus()
    {
        int rdn = Random.Range(1, 2);

        if (rdn == 1)
        {
            RandomDropBonus();
        }
    }
    #endregion
}