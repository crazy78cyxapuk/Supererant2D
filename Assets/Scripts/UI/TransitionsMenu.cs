using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionsMenu : MonoBehaviour
{
    [Header("Screen Menu")]
    [SerializeField] private GameObject TitleScreen, MainScreen, LevelsScreen, LevelsChoiceScreenMidtown,
                                        LevelsChoiceScreenUrban, LevelsChoiceScreenSuburban,
                                        LevelsChoiceScreenForest, LevelsChoiceScreenVillage, LevelsChoiceScreenDesert, SettingsScreen, AboutScreen;
    private GameObject LastScreen;

    [Header("Screens Game")]
    [SerializeField] private GameObject settingsBtn;
    [SerializeField] private GameObject AllSettingsScreen;

    
    private AudioSource audioSource;
    [Header("Audio")]
    [SerializeField] private AudioClip click;

    [SerializeField] public Image loadImg;
    private Animator animatorImg;

    public GameObject SceneLoadForLoadImage;

    public AsyncOperation loadingSceneOperation;

    [SerializeField] private bool isSceneLvl = false;


    private static TransitionsMenu instance;
    public static TransitionsMenu Instance => instance;

    private void InitSingleton()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    private void Awake()
    {
        InitSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (isSceneLvl)
        {
            animatorImg = loadImg.GetComponent<Animator>();
            animatorImg.SetTrigger("isStartScene");
        }
    }

    public void TransitionScene(string scene)
    {
        PlaySound(click);

        if (isSceneLvl)
        {
            SceneLoadForLoadImage.SetActive(true);

            animatorImg.SetTrigger("isEndScene");
            loadingSceneOperation = SceneManager.LoadSceneAsync(scene);
            loadingSceneOperation.allowSceneActivation = false;
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.volume = PlayerPrefs.GetFloat("sound");
        audioSource.PlayOneShot(clip);
    }

    #region Buttons in scene "Menu"

    public void TitleToMenu()
    {
        PlaySound(click);

        MainScreen.SetActive(true);
        TitleScreen.SetActive(false);
    }

    public void MainToLevels()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }

    public void LevelsToChoiceLevel()
    {
        PlaySound(click);

        //LevelsChoiceScreen.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideSettingsScreen()
    {
        PlaySound(click);

        SettingsScreen.SetActive(false);
        LastScreen.SetActive(true);
    }

    public void ShowSettingsScreen(GameObject obj)
    {
        PlaySound(click);

        LastScreen = obj;
        LastScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }

    public void HideAboutScreen()
    {
        PlaySound(click);

        SettingsScreen.SetActive(true);
        AboutScreen.SetActive(false);
    }

    public void ShowAboutScreen()
    {
        PlaySound(click);

        AboutScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenMidtown()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenMidtown.SetActive(false);
    }

    public void ShowChoiceLevelsMidtown()
    {
        PlaySound(click);

        LevelsChoiceScreenMidtown.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenUrban()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenUrban.SetActive(false);
    }

    public void ShowChoiceLevelsUrban()
    {
        PlaySound(click);

        LevelsChoiceScreenUrban.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenSuburban()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenSuburban.SetActive(false);
    }

    public void ShowChoiceLevelsSuburban()
    {
        PlaySound(click);

        LevelsChoiceScreenSuburban.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenForest()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenForest.SetActive(false);
    }

    public void ShowChoiceLevelsForest()
    {
        PlaySound(click);

        LevelsChoiceScreenForest.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenVillage()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenVillage.SetActive(false);
    }

    public void ShowChoiceLevelsVillage()
    {
        PlaySound(click);

        LevelsChoiceScreenVillage.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenDesert()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenDesert.SetActive(false);
    }

    public void ShowChoiceLevelsDesert()
    {
        PlaySound(click);

        LevelsChoiceScreenDesert.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    #endregion

    #region Buttons in game

    public void ShowSettings()
    {
        PlaySound(click);

        settingsBtn.SetActive(false);
        AllSettingsScreen.SetActive(true);
    }

    public void HideAllSettings()
    {
        PlaySound(click);

        Animator anim = AllSettingsScreen.GetComponent<Animator>();
        anim.SetBool("isHide", true);
        StartCoroutine(DisabledAllSettings());
    }

    IEnumerator DisabledAllSettings()
    {
        yield return new WaitForSeconds(1.6f);
        AllSettingsScreen.SetActive(false);
        settingsBtn.SetActive(true);
    }

    #endregion
}
