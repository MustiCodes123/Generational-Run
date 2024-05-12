using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContact : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy in contact with player");
            collision.gameObject.GetComponent<TakeDamage>().TakeDamageForPlayer(5);
        }
    }



}
