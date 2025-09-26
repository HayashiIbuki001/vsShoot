using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary> ’e‚ğŒ‚‚Á‚½ƒvƒŒƒCƒ„[ </summary>
    public GameObject shooter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(this.gameObject);
        }
    }
}
