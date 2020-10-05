using UnityEngine;
using System.Collections;

public class ExitFromLevel : MonoBehaviour
{
    [SerializeField] private float _timeBeforLoadNextLevel;

    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
            StartCoroutine(LevelWin());
    }

    public void ColliderEnabled(bool trueOrFalse)
    {
        _collider.enabled = trueOrFalse;
    }

    private IEnumerator LevelWin()
    {
        Time.timeScale = 0f;
        AudioManager.instance.Play("GoodLevelEnd");
        yield return new WaitForSecondsRealtime(_timeBeforLoadNextLevel);
        GAME_MANAGER.instance.LoadNextLevel(GAME_MANAGER.instance.GetNextLevel());
    }
}
