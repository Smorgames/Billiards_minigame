using UnityEngine;
using TMPro;

public class ScoreIndicator : MonoBehaviour
{
    [SerializeField] private IndicatorMod _indicatorMod;
    [SerializeField] private TextMeshProUGUI _bestScore;

    private void Start()
    {
        if (_indicatorMod == IndicatorMod.BestScoreAtTheStart)
            _bestScore.text = GAME_MANAGER.instance.GetBestScore().ToString();
    }

    private void OnEnable()
    {
        if (_indicatorMod == IndicatorMod.BestScoreOnEnable)
        {
            if (GAME_MANAGER.instance.GetScore() > GAME_MANAGER.instance.GetBestScore())
                GAME_MANAGER.instance.SetBestScore(GAME_MANAGER.instance.GetScore());

            _bestScore.text = GAME_MANAGER.instance.GetBestScore().ToString();
        }

        if (_indicatorMod == IndicatorMod.ScoreOnEnable)
            _bestScore.text = GAME_MANAGER.instance.GetScore().ToString();
    }
}

[System.Serializable]
enum IndicatorMod
{
    BestScoreAtTheStart,
    BestScoreOnEnable,
    ScoreOnEnable
}
