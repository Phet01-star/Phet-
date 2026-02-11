using UnityEngine;

public class enemy : MonoBehaviour
{
    public EnemyManager manager;

    private void OnDestroy()
    {
        if (manager != null)
        {
            manager.EnemyDied();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
