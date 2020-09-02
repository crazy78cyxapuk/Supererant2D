using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsMenu : MonoBehaviour
{
    public void TransitionMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TransitionGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void TransitionGame1()
    {
        SceneManager.LoadScene("Game1");
    }
}
