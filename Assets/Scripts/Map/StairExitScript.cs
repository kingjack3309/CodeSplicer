using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairExitScript : MonoBehaviour
{
    StairScript stairScript;

    private void Start()
    {
        stairScript = GetComponentInParent<StairScript>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            stairScript.stepCollider.enabled = true;
        }
    }
}
