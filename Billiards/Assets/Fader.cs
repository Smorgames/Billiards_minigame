using UnityEngine;

public class Fader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        GAME_MANAGER.instance.LoadNextLevel();
    }
}
