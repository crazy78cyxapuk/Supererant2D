using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTouch : MonoBehaviour
{
    private bool _rotateObj = false;
    private Vector3 lastPositionMouse;

    [SerializeField] private float maxAngles, minAngles;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        if(_rotateObj == true)
        {
            Rotate();
        }
    }

    private void OnMouseDrag()
    {
        _rotateObj = true;
    }

    private void OnMouseUp()
    {
        _rotateObj = false;
    }

    private void Rotate()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (mousePosition.y > lastPositionMouse.y)
        {
            if (TranslateEulerToRotate(transform.localRotation.eulerAngles.z) < maxAngles)
            {
                transform.Rotate(new Vector3(0, 0, 5), rotateSpeed, Space.World);
            }
        }

        if (mousePosition.y < lastPositionMouse.y)
        {
            if (TranslateEulerToRotate(transform.localRotation.eulerAngles.z) > minAngles)
            {
                transform.Rotate(new Vector3(0, 0, -5), rotateSpeed, Space.World);
            }
        }

        lastPositionMouse = mousePosition;
    }

    private float TranslateEulerToRotate(float x)
    {
        if (x >= -90 && x <= 90)
            return x;

        x = x % 180;

        if (x > 0)
            x -= 180;
        else
            x += 180;

        return x;
    }
}
