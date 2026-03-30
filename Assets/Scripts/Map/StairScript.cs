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
    private bool standingOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        stepCollider = gameObject.GetComponent <TilemapCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && standingOnPlatform)
        {
            stepCollider.enabled = false;
        }
    }

    private void OnCollisionEnter2D()
    {
        standingOnPlatform = true;
    }

    private void OnCollisionExit2D()
    {
        standingOnPlatform = false;
    }

}
