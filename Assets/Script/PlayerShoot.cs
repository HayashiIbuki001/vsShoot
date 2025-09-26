using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [Header("弾発射関連")]
    [SerializeField,Tooltip("弾の発射速度")] public float bulletSpeed = 1.0f;
    public GameObject bulletObj;
    /// <summary> 弾の発射位置</summary>
    public Transform firePoint;
    public KeyCode shootKey;

    [Header("弾数情報")]
    [SerializeField] private int maxAmmo = 10;
    [SerializeField,Tooltip("1ポイント回復までの時間")] private float regenTime = 1.0f;
    [SerializeField,Tooltip("弾のクールタイム")] private float coolTime = 1.0f;
    private int ammo = 0;
    private float regenTimer = 0;
    private float shootTimer = 0;

    [Header("UI")]
    public TextMeshProUGUI ammoText;


    private void Update()
    {
        Shoot();

        ShootCoolTime();
    }

    private void Shoot()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKeyDown(shootKey))
        {
            if (ammo > 0)
            {
                if (shootTimer >= coolTime)
                {
                    GameObject bullet = Instantiate(bulletObj, firePoint.position, firePoint.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.linearVelocity = firePoint.up * bulletSpeed;

                    ammo--;
                    shootTimer = 0;
                    ammoText.text = ammo.ToString();
                    //Debug.Log($"残り弾数：{ammo}発");
                }
            }
        }
    }

    private void ShootCoolTime()
    {
        if (ammo < maxAmmo)
        {
            regenTimer += Time.deltaTime;

            if (regenTimer >= regenTime)
            {
                ammo++;
                regenTimer = 0;

                ammoText.text = ammo.ToString();
                //Debug.Log($"弾数を回復：{ammo}発");
            }
        }
    }
}
