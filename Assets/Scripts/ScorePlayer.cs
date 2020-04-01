using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    public static int _nbEnemy = 0;
    public static int _nbWalkyKill = 0;
    public static int _nbWhellyKill = 0;

    public int NbEnemy
    {
        get
        {
            return _nbEnemy;
        }
        set
        {
            _nbEnemy = value;
        }
    }

    public int NbWalkyKill
    {
        get
        {
            return _nbWalkyKill;
        }
        set
        {
            _nbWalkyKill = value;
        }
    }

    public int NbWhellyKill
    {
        get
        {
            return _nbWhellyKill;
        }
        set
        {
            _nbWhellyKill = value;
        }
    }
}
