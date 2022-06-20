using UnityEngine;

public class MobileView : MonoBehaviour
{
    private GameObject _variableJoystick;
    private void Awake()
    {
        _variableJoystick = transform.GetChild(0).gameObject;
    }
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            _variableJoystick.SetActive(true);
        }
        else
        {
            _variableJoystick.SetActive(false);
        }
    }
}
