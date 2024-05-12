using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInFrame : MonoBehaviour
{

    public Canvas gameOver;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<TakeDamage>().TakeDamageForPlayer(10);
            gameOver.gameObject.SetActive(true);
            gameOver.enabled = true;
            Time.timeScale = 0f;
        }
    }





}
