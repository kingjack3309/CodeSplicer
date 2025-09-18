using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] float knockbackX = 0;
    [SerializeField] float knockbackY = 15;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControllerScript>().RemoveHealth(10);
            collision.gameObject.GetComponent<PlayerControllerScript>().Knockback(knockbackX, knockbackY);
        }
    }
}
