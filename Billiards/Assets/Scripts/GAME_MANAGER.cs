using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GAME_MANAGER : MonoBehaviour
{
    public static GAME_MANAGER instance;

    private void Awake()
    {
        instance = this;
    }

    private int _score;

    [SerializeField] private GameObject _losePanel;

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _coin;

    [SerializeField] private string _nextLevel;

    [SerializeField] private GameObject _exitFromLevel;
    private ExitFromLevel _exitFromLevelComponent;

    private void Start()
    {
        _exitFromLevelComponent = _exitFromLevel.GetComponent<ExitFromLevel>();

        SetStartScore();

        for (int i = 0; i < _spawnPoints.Length; i++)
            Instantiate(_coin, _spawnPoints[i].position, Quaternion.identity);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.N))
    //        LoadNextLevel(_nextLevel);
    //}

    public void LoadNextLevel(string nextLevel)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextLevel);
    }

    public int GetScore()
    {
        return _score;
    }

    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore", 0);
    }

    public void SetBestScore(int amount)
    {
        PlayerPrefs.SetInt("BestScore", amount);
    }

    private void SetStartScore()
    {
        _score = 0;
    }

    public void AddScore(int amount)
    {
        _score += amount;
        if (_score == _spawnPoints.Length)
            _exitFromLevelComponent.ColliderEnabled(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string GetNextLevel()
    {
        return _nextLevel;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _losePanel.SetActive(true);
    }
}
