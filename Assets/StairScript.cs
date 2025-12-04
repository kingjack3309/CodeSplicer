using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class StairScript : MonoBehaviour
{

    CompositeCollider2D stairCollider;

    TilemapCollider2D stepCollider;

    //bool wannaCollide = true;

    // Start is called before the first frame update
    void Start()
    {
        stairCollider = gameObject.GetComponent<CompositeCollider2D>();
        stepCollider = gameObject.GetComponent <TilemapCollider2D>();
    }

    //private void Update()
    //{
    //    if (wannaCollide)
    //    {
    //        stairCollider.enabled = true;
    //    }
        
    //    if (!wannaCollide)
    //    {
    //        stairCollider.enabled = false;
    //    }

    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //wannaCollide = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.S))
            {
                //wannaCollide = false;

                //stairCollider.enabled = false;
                stepCollider.enabled = false;
                Debug.Log("Stair collider off");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //wannaCollide = true;

            //stairCollider.enabled = true;
            stepCollider.enabled = true;
            Debug.Log("Stair collider on");
        }
    }
}
