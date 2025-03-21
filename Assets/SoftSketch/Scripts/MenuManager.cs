using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panel")]
    public Button startButton;
    public Button levelButton;
    public Button settingsButton;
    public Button exitButton;
    [Header("Setting Panel")]
    public GameObject settingsPanel;
    public Button closeSettingsButton;
    public Toggle enToggle;
    public Toggle zhcnToggle;
    public Toggle zhhkToggle;
    private ToggleGroup _toggleGroup;
    public Slider volumeSlider;
    private AudioSource bgmSource;
    [Header("Level Panel")]
    public GameObject levelPanel;
    public List<Button> levelButtons;
    public Button closeLevelButton;
    
    private const string LanguageKey = "SelectedLanguage";

    private void Awake()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
        bgmSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    private void Start()
    {
        startButton?.onClick.AddListener(() => LoadLevel(1));
        levelButton?.onClick.AddListener(() => levelPanel.SetActive(true));
        settingsButton?.onClick.AddListener(() => settingsPanel.SetActive(true));
        exitButton?.onClick.AddListener(ExitGame);
        closeSettingsButton?.onClick.AddListener(() => settingsPanel.SetActive(false));
        enToggle.group = _toggleGroup;
        zhcnToggle.group = _toggleGroup;
        zhhkToggle.group = _toggleGroup;
        enToggle?.onValueChanged.AddListener(a => StartCoroutine(UIManager.ChangeLanguage("en")));
        zhcnToggle?.onValueChanged.AddListener(a => StartCoroutine(UIManager.ChangeLanguage("zh-CN")));
        zhhkToggle?.onValueChanged.AddListener(a => StartCoroutine(UIManager.ChangeLanguage("zh-HK")));
        volumeSlider?.onValueChanged.AddListener(val => bgmSource.volume = val);
        closeLevelButton?.onClick.AddListener(() => levelPanel.SetActive(false));
        for (int i = 0; i < 10; i++)
        {
            int level_num = i + 1;
            levelButtons[i]?.onClick.AddListener(() => LoadLevel(level_num));
        }

        string savedLang = PlayerPrefs.GetString(LanguageKey);
        enToggle.isOn = savedLang == "en";
        zhcnToggle.isOn = savedLang == "zh-CN";
        zhhkToggle.isOn = savedLang == "zh-HK";
        StartCoroutine(UIManager.ChangeLanguage(savedLang));
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
