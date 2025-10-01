using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UppercutMod : ModData
{
    GameObject UppercutPrefab;

    GameObject player;

    private float playerX;
    private float playerY;

    private void Awake()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
    }
    
    public override void Execute()
    {
        Instantiate(UppercutPrefab, new Vector3(playerX, playerY, 0));
    }
}
