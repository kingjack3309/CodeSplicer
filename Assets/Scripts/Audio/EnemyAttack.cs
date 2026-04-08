using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyAttack : MonoBehaviour
{

    GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            StartCoroutine(GoombaSlap());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }

    IEnumerator GoombaSlap()
    {
        if (player != null)
        {
            player.GetComponent<PlayerControllerScript>().RemoveHealth(10);
            yield return new WaitForSeconds(0.7f);
            StartCoroutine(GoombaSlap());
        }
    }
}
