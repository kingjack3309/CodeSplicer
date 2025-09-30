using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackMod : ModData
{
    public new string rarity = "Common";
    public override void Execute()
    {
        Debug.Log("bang");
    }
}
