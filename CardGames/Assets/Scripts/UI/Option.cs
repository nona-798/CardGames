using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum ScreenMode
{
    FullScreen = 0, Window
}
public enum ScreenSize
{
    x1080 = 0, x1050, x1024
}
public class Option : MonoBehaviour
{
    [Header("Screen")]
    [SerializeField]
    private TMP_Dropdown dropScreenMode;
    [SerializeField]
    private TMP_Dropdown dropScreenSize;

    private bool IsFullScreen;
    private void Awake()
    {
        InitScreen();
    }
    private void Start()
    {
        ChangeScreen();
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            this.gameObject.SetActive(false);
        }
    }
    private void InitScreen()
    {
        List<string> mode = new List<string> { "FullScreen", "Window" };
        List<string> size = new List<string> { "1920x1080", "1680x1050", "1280x1024" };

        // 스크린 모드 옵션 초기화/ 생성
        dropScreenMode.ClearOptions();
        dropScreenMode.AddOptions(mode);

        dropScreenSize.ClearOptions();
        dropScreenSize.AddOptions(size);

        IsFullScreen = true;
    }
    private void ChangeScreen()
    {
        dropScreenMode.onValueChanged.AddListener(mode => ChangeScreenMode((ScreenMode)mode));
        dropScreenSize.onValueChanged.AddListener(size => ChangeScreenSize((ScreenSize)size));

        // 초기 설정
        switch (dropScreenMode.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
                break;
            case 1:
                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                break;
        }
        switch (dropScreenSize.value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, IsFullScreen);
                break;
            case 1:
                Screen.SetResolution(1680, 1050, IsFullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 1024, IsFullScreen);
                break;
        }
    }
    private void ChangeScreenMode(ScreenMode mode)
    {
        switch(mode)
        {
            case ScreenMode.FullScreen:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                IsFullScreen = true;
                break;
            case ScreenMode.Window:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                IsFullScreen = false;
                break;
        }
    }
    private void ChangeScreenSize(ScreenSize size)
    {
        switch (size)
        {
            case ScreenSize.x1080:
                Screen.SetResolution(1920, 1080, IsFullScreen);
                break;
            case ScreenSize.x1050:
                Screen.SetResolution(1680, 1050, IsFullScreen);
                break;
            case ScreenSize.x1024:
                Screen.SetResolution(1280, 1024, IsFullScreen);
                break;
        }
    }
}
