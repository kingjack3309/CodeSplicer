using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class CodePickupData : ScriptableObject
{
    public string rarity = "Common";
    //public string modType = "OnLeftClick";

    //public bool isParentFunction = true;



    public abstract void Execute();

    //public void OnLeftClick()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        //call child function
    //    }
    //}

    //public void AttackEnemy()
    //{

    //}
}
