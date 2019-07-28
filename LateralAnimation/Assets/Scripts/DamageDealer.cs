using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 100;

    void Start()
    {
        Debug.Log(" THIS IS BEING CALLED!!!");
    }

    public int GetDamage()
    {
        return damage;
    }
    
    public void Hit()
    {
        Debug.Log("DEADDDDDDDDD");
        Destroy(gameObject);

    }
}
