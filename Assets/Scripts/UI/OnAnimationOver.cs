using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnAnimationOver : MonoBehaviour
{
    public Color startColor;

    public void ContinuedLoadScene() 
    {
        SceneManager.LoadScene(TransitionsMenu.Instance.nextScene);
        //TransitionsMenu.Instance.loadingSceneOperation.allowSceneActivation = true;
    }

    public void HideImage()
    {
        TransitionsMenu.Instance.SceneLoadForLoadImage.SetActive(false);
        TransitionsMenu.Instance.loadImg.GetComponent<Image>().color = startColor;
    }
}
