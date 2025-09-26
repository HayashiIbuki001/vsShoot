using TMPro;
using UnityEngine;

public class ItemBlock : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] public GameObject pointPrefub;
    [SerializeField] private float fallSpeed;

    int hp = 0;

    private void Start()
    {
        hp = Random.Range(1, 5);
        text.text = hp.ToString();
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            hp--;
            text.text = hp.ToString();

            if (hp <= 0)
            {
                GameObject pointObj = Instantiate(pointPrefub, transform.position, Quaternion.identity);

                // shooter‚ðŽæ“¾
                GameObject shooter = collision.gameObject.GetComponent<Bullet>().shooter;

                // —Ž‰º•ûŒü‚ðŽw’è
                Vector2 fall = (shooter.CompareTag("Player1")) ? Vector2.down : Vector2.up;

                Rigidbody2D rb = pointObj.GetComponent<Rigidbody2D>();
                rb.linearVelocity = fall * fallSpeed;

                Destroy(gameObject);
            }
        }
    }
}
