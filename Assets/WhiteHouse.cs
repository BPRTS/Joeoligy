using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteHouse : MonoBehaviour
{
    public int health = 100;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= collision.gameObject.GetComponent<EnemyBehaviour>().damage;
        }
        
    }
}
