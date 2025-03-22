using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Main Panel")]
    public Button settingsButton;
    public Button replayButton;
    public List<GameObject> slotGroup;
    [Header("Setting Panel")]
    public GameObject settingPanel;
    public Toggle enToggle;
    public Toggle zhcnToggle;
    public Toggle zhhkToggle;
    public Button backButton;
    public Button menuButton;
    public Slider volumeSlider;
    private AudioSource bgmSource;
    [Header("Win Panel")]
    public Button nextStageButton;
    public Button returnButton;
    
    private ToggleGroup _toggleGroup;
    
    public SkinData currData;
    private const string LanguageKey = "SelectedLanguage";
    
    private void Awake()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
        bgmSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        settingsButton?.onClick.AddListener(PauseLevel);
        backButton?.onClick.AddListener(PauseLevel);
        menuButton?.onClick.AddListener(() => GameManager.Instance.LoadMainMenu());
        volumeSlider?.onValueChanged.AddListener(val => bgmSource.volume = val);
        nextStageButton?.onClick.AddListener(() => GameManager.Instance.LoadNextLevel(sceneName));
        returnButton?.onClick.AddListener(() => GameManager.Instance.LoadMainMenu());
        enToggle.group = _toggleGroup;
        zhcnToggle.group = _toggleGroup;
        zhhkToggle.group = _toggleGroup;
        enToggle?.onValueChanged.AddListener(a => StartCoroutine(ChangeLanguage("en")));
        zhcnToggle?.onValueChanged.AddListener(a => StartCoroutine(ChangeLanguage("zh-CN")));
        zhhkToggle?.onValueChanged.AddListener(a => StartCoroutine(ChangeLanguage("zh-HK")));
        replayButton?.onClick.AddListener(() => GameManager.Instance.LoadLevel(sceneName));
        if (slotGroup[0] == null)
        {
            Transform slot = GameObject.Find("Canvas").transform.GetChild(0);
            for (int i = 0; i < 12; i++)
            {
                slotGroup[i] = slot.GetChild(i).gameObject;
            }
        }

        string savedLang = PlayerPrefs.GetString(LanguageKey);
        enToggle.isOn = savedLang == "en";
        zhcnToggle.isOn = savedLang == "zh-CN";
        zhhkToggle.isOn = savedLang == "zh-HK";
        StartCoroutine(ChangeLanguage(savedLang));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseLevel();
        }
    }

    private void PauseLevel()
    {
        settingPanel?.SetActive(!GameManager.Instance.IsPause);
        GameManager.Instance.IsPause = !GameManager.Instance.IsPause;
    }
    
    public void UpdateInventories(List<Inventory> invList)
    {
        for (int i = 0; i < invList.Count; i++)
        {
            if (slotGroup[i].transform.GetChild(1).TryGetComponent(out Image image))
            {
                image.gameObject.SetActive(true);
                switch (invList[i].Type)
                {
                    case InventoryType.Square:
                        image.sprite = currData.Square;
                        break;
                    case InventoryType.Interact:
                        image.sprite = currData.Interact;
                        break;
                    case InventoryType.Heater:
                        image.sprite = currData.Heater;
                        break;
                    case InventoryType.Gyro:
                        image.sprite = currData.Gyro;
                        break;
                }
            }
            if (slotGroup[i].transform.GetChild(2).TryGetComponent(out Text text))
            {
                text.gameObject.SetActive(true);
                text.text = invList[i].InventoryNum.ToString();
            }
            slotGroup[i].SetActive(true);
        }
    }

    public static IEnumerator<AsyncOperationHandle<LocalizationSettings>> ChangeLanguage(string langCode)
    {
        yield return LocalizationSettings.InitializationOperation;
        PlayerPrefs.SetString(LanguageKey, langCode);
        PlayerPrefs.Save();
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(langCode);
        LocalizationSettings.Instance.SetSelectedLocale(locale);
    }
}