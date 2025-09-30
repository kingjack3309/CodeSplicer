using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTabletManager : MonoBehaviour
{

    [SerializeField] ModData thisMod;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //give a prompt to pick up the code
            collision.GetComponent<PlayerControllerScript>().AddMod(thisMod);
            gameObject.SetActive(false);
        }
    }
}
