using UnityEngine;

public class GoombaHurtbox : MonoBehaviour
{
    [SerializeField] GameObject parentObject;
    public float bounce = 1.5f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.rigidbody.linearVelocityY = bounce;
            //spawn 1&0 particle prefab that fall onto the floor
            Destroy(parentObject);
        }
    }
}
