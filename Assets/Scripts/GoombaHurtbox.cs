using UnityEngine;

public class GoombaHurtbox : MonoBehaviour
{
    [SerializeField] GameObject parentObject;

    [SerializeField] GameObject bloodParticles;

    public float bounce = 1.5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject blood = Instantiate(bloodParticles, new Vector2(parentObject.transform.position.x, parentObject.transform.position.y), Quaternion.identity);
            other.GetComponent<Rigidbody2D>().linearVelocityY = bounce;
            Destroy(parentObject);
        }
    }
}
