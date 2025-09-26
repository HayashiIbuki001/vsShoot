using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;

    public KeyCode moveLeft;
    public KeyCode moveRight;

    float move = 0;

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

        float clampX = transform.position.x + move * moveSpeed;
        clampX = Mathf.Clamp(clampX, -8.3f, 8.3f);

        transform.position = new Vector3(clampX, transform.position.y, transform.position.z);
    }
}
