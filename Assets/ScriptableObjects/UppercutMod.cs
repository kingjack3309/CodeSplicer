using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UppercutMod : ModData
{
    public GameObject uppercutPrefab;

    public Vector3 uppercutAngle;

    public float offsetX;
    public float offsetY;
    Vector3 offsetVector;
   
    public override void Execute()
    {
        uppercutPrefab.GetComponent<SpriteRenderer>().flipX = false;

        if (GameObject.Find("player").GetComponent<PlayerControllerScript>().isFacingRight)
        {
            offsetVector = new Vector3(offsetX, offsetY, 0);
            uppercutPrefab.transform.eulerAngles = -uppercutAngle;

        }
        else
        {
            offsetVector = new Vector3(-offsetX, offsetY, 0);
            uppercutPrefab.transform.eulerAngles = uppercutAngle;
        }
        Instantiate(uppercutPrefab, GameObject.Find("player").transform.position + offsetVector, uppercutPrefab.transform.rotation, GameObject.Find("player").transform);
    }
}
