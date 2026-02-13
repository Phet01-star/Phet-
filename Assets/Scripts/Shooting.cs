using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float bulletSpeed = 30f;
    public float fireRate = 0.1f; // Smaller number = faster firing

    [Header("References")]
    public PoolingManager poolManager;
    public GameObject shootPos;

    private float nextFireTime = 0f;
    void Awake()
    {
        poolManager = FindAnyObjectByType<PoolingManager>();
    }

    void Update()
    {
        // Use GetKey to detect if the button is being held down
        if (Input.GetKey(KeyCode.F))
        {
            if (Time.time >= nextFireTime)
            {
                FireBullet();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void FireBullet()
    {
        GameObject bulletObj = poolManager.GetPoolObject();
        if (bulletObj != null)
        {
            // Position and rotate the bullet to the gun's barrel
            bulletObj.transform.position = shootPos.transform.position;
            bulletObj.transform.rotation = shootPos.transform.rotation;

            // Activate it (since it was hidden in the pool)
            bulletObj.SetActive(true);

            Rigidbody rb = bulletObj.GetComponent<Rigidbody>();
            if (rb == null) rb = bulletObj.AddComponent<Rigidbody>();

            // 3. Reset velocity so old momentum doesn't carry over
            // rb.linearVelocity = Vector3.zero;
            // rb.angularVelocity = Vector3.zero;

            // Apply new velocity
            rb.linearVelocity = shootPos.transform.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Pool is empty! Increase the pool size in the PoolingManager.");
        }

    }
}