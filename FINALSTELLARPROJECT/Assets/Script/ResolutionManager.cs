using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    struct ResolutionOption
    {
        public int width;
        public int height;

        public ResolutionOption(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    ResolutionOption[] resolutions = new ResolutionOption[]
    {
        new ResolutionOption(1920, 1080),
        new ResolutionOption(1600, 900),
        new ResolutionOption(1366, 768),
        new ResolutionOption(1280, 720),
    };

    void Start()
    {
        resolutionDropdown.ClearOptions();

        foreach(ResolutionOption option in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(option.width + "x" + option.height));
        }
        resolutionDropdown.RefreshShownValue();
        // 从PlayerPrefs中读取保存的分辨率和全屏选项
        int savedResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex", 0);
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        resolutionDropdown.value = savedResolutionIndex;
        fullscreenToggle.isOn = savedFullscreen;

        // 应用保存的分辨率和全屏选项
        OnResolutionChange(savedResolutionIndex);
        OnFullscreenToggle();

        resolutionDropdown.onValueChanged.AddListener(delegate {
            OnResolutionChange(resolutionDropdown.value);
        });

        fullscreenToggle.onValueChanged.AddListener(delegate {
            OnFullscreenToggle();
        });
    }

    void OnResolutionChange(int index)
    {
        ResolutionOption selectedResolution = resolutions[index];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);

        // 保存玩家的选择
        PlayerPrefs.SetInt("ResolutionIndex", index);
    }

    void OnFullscreenToggle()
    {
        Screen.fullScreen = fullscreenToggle.isOn;

        // 保存玩家的选择
        PlayerPrefs.SetInt("Fullscreen", fullscreenToggle.isOn ? 1 : 0);
    }
}