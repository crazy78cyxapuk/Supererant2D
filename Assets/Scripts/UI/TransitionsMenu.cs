using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsMenu : MonoBehaviour
{
    public void TransitionScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
