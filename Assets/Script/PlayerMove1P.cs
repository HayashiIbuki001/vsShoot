using UnityEngine;

public class PlayerMove1P : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;

    float move = 0;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            move = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1;
        }
        else
        {
            move = 0;
        }

        transform.Translate(move * moveSpeed, 0, 0);
    }
}
