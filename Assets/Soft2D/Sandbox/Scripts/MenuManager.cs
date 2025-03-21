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
    public Button closeSettingsButton;
    public GameObject levelPanel;
    public List<Button> levelButtons;
    public Button closeLevelButton;

    private void Start()
    {
        startButton?.onClick.AddListener(() => LoadLevel(1));
        levelButton?.onClick.AddListener(() => levelPanel.SetActive(true));
        settingsButton?.onClick.AddListener(() => settingsPanel.SetActive(true));
        exitButton?.onClick.AddListener(ExitGame);
        closeSettingsButton?.onClick.AddListener(() => settingsPanel.SetActive(false));
        closeLevelButton?.onClick.AddListener(() => levelPanel.SetActive(false));
        for (int i = 0; i < 10; i++)
        {
            int level_num = i + 1;
            levelButtons[i]?.onClick.AddListener(() => LoadLevel(level_num));
        }
    }

    private void LoadLevel(int i)
    {
        Debug.Log("Loading Level" + i);
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
