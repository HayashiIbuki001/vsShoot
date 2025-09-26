using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;

    public KeyCode moveLeft;
    public KeyCode moveRight;

    float move = 0;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(moveLeft))
        {
            move = -1;
        }
        else if (Input.GetKey(moveRight))
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
