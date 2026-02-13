using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public GameObject bulletObj;
    public GameObject[] bulletPool;
    [SerializeField] private int poolSize;

    void Awake()
    {
        // 1. Initialize the array with the desired size
        bulletPool = new GameObject[poolSize];

        // 2. Loop through and create the objects
        for (int i = 0; i < poolSize; i++)
        {
            // Instantiate the object, but keep it disabled initially
            GameObject obj = Instantiate(bulletObj, this.transform);
            obj.SetActive(false);
            // Store it in our array
            bulletPool[i] = obj;
        }
    }

    public GameObject GetPoolObject()
    {
        foreach (GameObject i in bulletPool)
        {
            if (i != null && !i.activeInHierarchy)
            {
                // We don't SetActive(true) here usually, 
                // because you might want to set its position first!
                return i;
            }
        }
        return null;
    }
}
