using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StairScript : MonoBehaviour
{
    [HideInInspector]
    public TilemapCollider2D stepCollider;

    public bool isFacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        stepCollider = gameObject.GetComponent <TilemapCollider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.S))
            {
                stepCollider.enabled = false;
                Debug.Log("Stair collider off");
            }
        }
    }
}
