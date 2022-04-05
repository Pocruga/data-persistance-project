using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highscoreText;

    [SerializeField]
    private TMP_InputField nameInputField;

    void Start()
    {
        highscoreText.text = GameManager.Instance.GetHighscoreText();
    }

    // ensure player name is set and start a new game
    public void StartNewGame()
    {
        string playerName = nameInputField.text;
        Debug.Log("Player Name: " + playerName);
        if (playerName == null || playerName.Length == 0)
            return;

        GameManager.Instance.PlayerName = playerName;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        
    }
}
