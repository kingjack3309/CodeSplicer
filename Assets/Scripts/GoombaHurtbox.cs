using UnityEngine;

public class GoombaHurtbox : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    public float bounce = 1.5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().linearVelocityY = bounce;
            //spawn 1&0 particle prefab that fall onto the floor
            Destroy(parentObject);
        }
    }
}
