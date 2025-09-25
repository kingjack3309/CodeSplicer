using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class ModData : ScriptableObject
{
    public string rarity = "Common";
    public abstract void Execute();
}
