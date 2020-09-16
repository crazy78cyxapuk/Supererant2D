using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject TitleScreen, MainScreen, LevelsScreen, LevelsChoiceScreen, SettingsScreen, AboutScreen;
    private GameObject LastScreen;

    [SerializeField] private GameObject settingsBtn;
    [SerializeField] private GameObject AllSettingsScreen;

    public void TransitionScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }



    #region Buttons in scene "Menu"

    public void TitleToMenu()
    {
        MainScreen.SetActive(true);
        TitleScreen.SetActive(false);
    }

    public void MainToLevels()
    {
        LevelsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }

    public void LevelsToChoiceLevel()
    {
        LevelsChoiceScreen.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    public void HideSettingsScreen()
    {
        SettingsScreen.SetActive(false);
        LastScreen.SetActive(true);
    }

    public void ShowSettingsScreen(GameObject obj)
    {
        LastScreen = obj;
        LastScreen.SetActive(false);
        SettingsScreen.SetActive(true);
    }

    public void HideAboutScreen()
    {
        SettingsScreen.SetActive(true);
        AboutScreen.SetActive(false);
    }

    public void ShowAboutScreen()
    {
        AboutScreen.SetActive(true);
        SettingsScreen.SetActive(false);
    }

    public void HideChoiceLevelsScreen()
    {
        LevelsScreen.SetActive(true);
        LevelsChoiceScreen.SetActive(false);
    }

    public void ShowChoiceLevelsScreen()
    {
        LevelsChoiceScreen.SetActive(true);
        LevelsScreen.SetActive(false);
    }

    #endregion

    #region Buttons in game

    public void ShowSettings()
    {
        settingsBtn.SetActive(false);
        AllSettingsScreen.SetActive(true);
    }

    public void HideAllSettings()
    {
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
