using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField,Tooltip("’e‚Ì”­ŽË‘¬“x")] public float bulletSpeed = 1.0f;

    public GameObject bulletObj;
    public Transform firePoint;
    public KeyCode shootKey;

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject bullet = Instantiate(bulletObj, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = firePoint.up * bulletSpeed;
        }
    }
}
