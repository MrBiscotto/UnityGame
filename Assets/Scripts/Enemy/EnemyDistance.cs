using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistance : Enemy
{
    protected float _hitPerSec = 0f;
    protected float _lastTimeHit = 0f;
    public GameObject _bullet;
    public Transform _spawnPoint;

    #region Getter Setter
    public float _HitPerSec
    {
        get
        {
            return this._hitPerSec;
        }
        set
        {
            _HitPerSec = value;
        }
    }

    public float _LastTimeHit
    {
        get
        {
            return this._lastTimeHit;
        }
        set
        {
            _lastTimeHit = value;
        }
    }
    #endregion

    /// <summary>
    /// Check If distance is correct to shoot
    /// </summary>
    protected void CheckShoot()
    {
        float posX = _target.position.x - transform.position.x;
        float posZ = _target.position.z - transform.position.z;
        if (Mathf.Abs(posX) <= _distance && Mathf.Abs(posZ) <= _distance)
        {
            if (Time.time > _lastTimeHit + (1 / _hitPerSec))
            {
                ShootBullet();
                _lastTimeHit = Time.time;
            }
        }
    }

    /// <summary>
    /// Create Bullet from the spawner point
    /// </summary>
    void ShootBullet()
    {
        GameObject bulletEnemySpawn = Instantiate(_bullet); ;
        bulletEnemySpawn.transform.position = _spawnPoint.position;
        bulletEnemySpawn.transform.rotation = _spawnPoint.rotation;
    }
}
