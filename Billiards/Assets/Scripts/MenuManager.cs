using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame(string levelNumber)
    {
        SceneManager.LoadScene(levelNumber);
    }
}
