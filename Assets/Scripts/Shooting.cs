using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform shootingPos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 50;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) Shoot();
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPos.position, Quaternion.identity);
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.linearVelocity = shootingPos.forward * bulletSpeed;
    }
}
