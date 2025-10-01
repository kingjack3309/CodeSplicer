using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UppercutMod : ModData
{
    public GameObject uppercutPrefab;

    Vector3 offset;
   
    public override void Execute()
    {
        if (GameObject.Find("player").GetComponent<PlayerControllerScript>().isFacingRight)
        {
            offset = new Vector3(2, 0, 0);
            uppercutPrefab.GetComponent<SpriteRenderer>().flipX = true;
            uppercutPrefab.transform.rotation = new Vector3(0, 0, 41.5f);
        }
        else
        {
            offset = new Vector3(-2, 0, 0);
            uppercutPrefab.GetComponent<SpriteRenderer>().flipX = false;
        }
        Instantiate(uppercutPrefab, GameObject.Find("player").transform.position + offset, uppercutPrefab.transform.rotation);
    }
}
