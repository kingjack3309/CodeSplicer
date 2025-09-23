using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeTabletManager : MonoBehaviour
{
    List<string> rarityLevels = new List<string>() {"Common", "Uncommon", "Rare", "Epic", "Legendary" };

    Dictionary<string, List<string>> tabletCode = new Dictionary<string, List<string>>();

    List<string> commonCode = new List<string>() {"OnLeftClick", "OnRightCick", "OnJump", };
    List<string> uncommonCode = new List<string>();
    List<string> rareCode = new List<string>();
    List<string> epicCode = new List<string>();
    List<string> legendaryCode = new List<string>();

    string rarity;

    [SerializeField] int rarityIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        rarity = rarityLevels[rarityIndex];

        tabletCode.Add("CommonCode", commonCode);
        tabletCode.Add("UncommonCode", uncommonCode);
        tabletCode.Add("RareCode", rareCode);
        tabletCode.Add("EpicCode", epicCode);
        tabletCode.Add("LegendaryCode", legendaryCode);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //give a prompt to pick up the code
            gameObject.SetActive(false);
        }
    }
}
