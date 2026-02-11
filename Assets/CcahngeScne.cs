using UnityEngine;
using UnityEngine.SceneManagement;

public class CcahngeScne : MonoBehaviour
{
    public int sceneIndex = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("ไอดำ");
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
