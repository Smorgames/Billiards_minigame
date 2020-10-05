using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelNumber : MonoBehaviour
{
    private TextMeshProUGUI _levelNumber;

    private void Start()
    {
        _levelNumber = GetComponent<TextMeshProUGUI>();

        string levelName = SceneManager.GetActiveScene().name;
        char[] levelNameLitterals = new char[levelName.Length];

        for (int i = 0; i < levelName.Length; i++)
            levelNameLitterals[i] = levelName.ToCharArray()[i];

        if (levelNameLitterals[levelName.Length - 2] == '0')
            _levelNumber.text = "LEVEL " + levelNameLitterals[levelName.Length - 1];
        else
            _levelNumber.text = "LEVEL " + levelNameLitterals[levelName.Length - 2] + levelNameLitterals[levelName.Length - 1];
    }
}
