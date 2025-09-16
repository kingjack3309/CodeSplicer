using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeHurtTrigger : MonoBehaviour
{

    [SerializeField] int damage = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControllerScript>().RemoveHealth(damage);
            gameObject.SetActive(false);
        }
    }
}
