using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionsMenu : MonoBehaviour
{
    [Header("Screen Menu")]
    [SerializeField] private GameObject TitleScreen, MainScreen, LevelsScreen, LevelsChoiceScreenMidtown, LevelsChoiceScreenCity, LevelsChoiceScreenCountry, SettingsScreen, AboutScreen;
    private GameObject LastScreen;

    [Header("Screens Game")]
    [SerializeField] private GameObject settingsBtn;
    [SerializeField] private GameObject AllSettingsScreen;

    
    private AudioSource audioSource;
    [Header("Audio")]
    [SerializeField] private AudioClip click;
    //[SerializeField] private AudioClip setting;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TransitionScene(string scene)
    {
        PlaySound(click);
        SceneManager.LoadScene(scene);
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

    public void HideChoiceLevelsScreenCity()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenCity.SetActive(false);
    }

    public void ShowChoiceLevelsCity()
    {
        PlaySound(click);

        LevelsChoiceScreenCity.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreenCountry()
    {
        PlaySound(click);

        LevelsScreen.SetActive(true);
        LevelsChoiceScreenCountry.SetActive(false);
    }

    public void ShowChoiceLevelsCountry()
    {
        PlaySound(click);

        LevelsChoiceScreenCountry.SetActive(true);
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
