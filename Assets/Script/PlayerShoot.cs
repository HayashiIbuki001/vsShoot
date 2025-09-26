using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [Header("�e���ˊ֘A")]
    [SerializeField,Tooltip("�e�̔��ˑ��x")] public float bulletSpeed = 1.0f;
    public GameObject bulletObj;
    /// <summary> �e�̔��ˈʒu</summary>
    public Transform firePoint;
    public KeyCode shootKey;

    [Header("�e�����")]
    [SerializeField] private int maxAmmo = 10;
    [SerializeField,Tooltip("1�|�C���g�񕜂܂ł̎���")] private float regenTime = 1.0f;
    [SerializeField,Tooltip("�e�̃N�[���^�C��")] private float coolTime = 1.0f;
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
                    //Debug.Log($"�c��e���F{ammo}��");
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
                //Debug.Log($"�e�����񕜁F{ammo}��");
            }
        }
    }
}
