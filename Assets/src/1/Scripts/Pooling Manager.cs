using UnityEngine;

public class PoolingManager : MonoBehaviour
{

    public GameObject bullet;

    public GameObject[] bulletArr;//ที่เก็บ
    
    public int poolSize = 200;//ขนาด

    void Awake()
    {
        bulletArr = new GameObject[poolSize];

        //เริ่ม instantiate
        for (int i = 0; i < poolSize ; i++)
        {
            GameObject obj = Instantiate(bullet, this.transform);//เก็บไว้ในตัวนี้
            obj.SetActive(false);//ปิดการใช้งาน

            bulletArr[i] = obj;//เก็บไว้ในอาเรย์
        }
    }

    public GameObject GetPoolOject()
    {
        foreach(GameObject obj in bulletArr)
        {
            if (obj != null)
            {
                if(!obj.activeInHierarchy)
                {
                   return obj;//ถ้าเจออันที่ไม่ใช้งานอยู่ก็ส่งกลับไป
                }
            }
        }
        return null;//ถ้าไม่เจออันที่ไม่ใช้งานอยู่ก็ส่งกลับไปเป็น null
    }
}
