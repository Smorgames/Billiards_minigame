using UnityEngine;

public class LosePanel : MonoBehaviour
{
    private void OnEnable()
    {
        AudioManager.instance.Play("Lose");
    }
}
