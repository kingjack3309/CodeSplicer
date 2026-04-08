using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> waveEnemies = new List<GameObject>();

    Collider2D spawnTrigger;

    private bool startupDone = false;

    private int nullCount = 0;

    private void Start()
    {
        spawnTrigger = GetComponent<Collider2D>();
        foreach (GameObject enemy in waveEnemies)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject enemy in waveEnemies)
            {
                enemy.SetActive(true);
            }

            spawnTrigger.enabled = false;

            startupDone = true;
            
        }
    }

    private void FixedUpdate()
    {
        nullCount = 0;

        foreach (GameObject enemy in waveEnemies)
        {
            if (startupDone && enemy == null)
            {
                nullCount++;
            }
        }

        if (waveEnemies.Count == nullCount)
        {
            Destroy(this.gameObject);
        }
    }
}
