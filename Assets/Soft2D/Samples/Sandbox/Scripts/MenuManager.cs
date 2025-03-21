using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public Button levelButton;
    public Button settingsButton;
    public Button exitButton;

    public GameObject settingsPanel;
    public GameObject levelPanel;

    private void Start()
    {
        startButton?.onClick.AddListener(LoadFirstLevel);
        levelButton?.onClick.AddListener(() => levelPanel.SetActive(true));
        settingsButton?.onClick.AddListener(() => settingsPanel.SetActive(true));
        exitButton?.onClick.AddListener(ExitGame);
    }

    private void LoadFirstLevel()
    {
        LoadLevel(1);
    }

    private void LoadLevel(int i)
    {
        SceneManager.LoadScene("Level " + i);
    }

    private void ExitGame()
    {
        if (Application.isEditor)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        else
        {
            Application.Quit();
        }
    }
}
