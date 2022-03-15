using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public InputField nameField;
    public Component startButton;

    private void Start()
    {
        startButton = gameObject.GetComponent("StartButton");

        LoadPlayerNameAndHighScoreSaved();
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        MenuManager.Instance.playerName = nameField.text;
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void LoadPlayerNameAndHighScoreSaved()
    {
        MenuManager.Instance.LoadPlayerNameAndHighScore();
        
        if (MenuManager.Instance.playerName != "")
        {
            bestScoreText.SetText("Best Score: " + MenuManager.Instance.playerName + " : " + MenuManager.Instance.highScore);
        }
    }
}
