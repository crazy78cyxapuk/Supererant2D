using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnAnimationOver : MonoBehaviour
{
    public Color startColor;

    public void ContinuedLoadScene() 
    {
        TransitionsMenu.Instance.loadingSceneOperation.allowSceneActivation = true;
    }

    public void HideImage()
    {
        TransitionsMenu.Instance.SceneLoadForLoadImage.SetActive(false);
        TransitionsMenu.Instance.loadImg.GetComponent<Image>().color = startColor;
    }
}
