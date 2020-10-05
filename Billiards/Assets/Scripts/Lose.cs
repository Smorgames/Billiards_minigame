using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
