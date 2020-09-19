using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider slider;

    private Camera cam;
    private float camPositionY;

    [HideInInspector] public bool clickHandle = false;

    private static SliderController instance;
    public static SliderController Instance => instance;

    private void Awake()
    {
        InitSingleton();
    }

    private void InitSingleton()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();

        cam = Camera.main;
        camPositionY = cam.transform.position.y;

        slider.maxValue = 0.99f;
    }

    private void Update()
    {
        if(clickHandle == false)
        {
            slider.value = (camPositionY - cam.transform.position.y) / (camPositionY - CameraFollow.Instance.minPositionY);
        }
        else
        {
            cam.transform.position = new Vector3(cam.transform.position.x, camPositionY - slider.value * (camPositionY - CameraFollow.Instance.minPositionY), cam.transform.position.z);
        }
    }

    public void SwapLogigHandle()
    {
        StartCoroutine(StopPositionCameraY());
    }

    IEnumerator StopPositionCameraY()
    {
        CameraFollow.Instance.stopPosition = true;

        yield return new WaitForSeconds(3f);
        CameraFollow.Instance.stopPosition = false;
        cam.GetComponent<CameraFollow>().enabled = true;
    }
}
