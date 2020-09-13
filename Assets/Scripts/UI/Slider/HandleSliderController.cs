using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleSliderController : MonoBehaviour
{
    private void OnMouseUp()
    {
        SliderController.Instance.clickHandle = false;
        SliderController.Instance.SwapLogigHandle();
    }

    private void OnMouseDown()
    {
        SliderController.Instance.clickHandle = true;
        Camera.main.GetComponent<CameraFollow>().enabled = false;

    }
}
