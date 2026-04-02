using UnityEngine;

public class ParticleDecay : MonoBehaviour
{

    ParticleSystem _particleSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (_particleSystem.isStopped == true)
        {
            Object.Destroy(this.gameObject);
            Debug.Log("Blood Decayed");
        }
    }
}
