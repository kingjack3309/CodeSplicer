using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemManager : MonoBehaviour
{

    private int gemAmmount = 0;

    // Start is called before the first frame update
    void Update()
    {
        gameObject.GetComponent<TMP_Text>().text = gemAmmount.ToString();
    }

    public void GainGems(int gems)
    {
        gemAmmount += gems;
    }
}
