using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highscoreText;

    [SerializeField]
    private TMP_InputField nameInputField;

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
    void Update()
    {
        
    }
}
