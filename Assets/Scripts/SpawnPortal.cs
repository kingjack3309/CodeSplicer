using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnPortal : MonoBehaviour
{
    public List<GameObject> waves = new List<GameObject>();
    public GameObject portal;

    private int nullCount = 0;

    private void Start()
    {
        portal = FindFirstObjectByType<PortalScript>().gameObject;
        StartCoroutine(PortalDisabler());
    }

    private void FixedUpdate()
    {
        nullCount = 0;

        foreach (GameObject wave in waves) 
        {
            if (wave == null) 
            {
                nullCount++;
            }
                        
        }

        if (waves.Count == nullCount)
        {
            portal.SetActive(true);
        }
    }

    IEnumerator PortalDisabler()
    {
        yield return new WaitForSeconds(0.5f);
        portal.SetActive(false);
    }
}
