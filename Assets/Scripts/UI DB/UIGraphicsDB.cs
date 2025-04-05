using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGraphicsDB : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] Button _settingsbutton;
    [SerializeField] GameObject _settingsPanel;
    [SerializeField] Toggle _vsyncToggle;
    [SerializeField] Toggle _fullscreenToggle;
    [SerializeField] Toggle _noShadowToggle;
    [SerializeField] TMP_Dropdown _qualityDrop;
    [SerializeField] TMP_Dropdown _resolutionDrop;
    [SerializeField] Slider _brightnessDrop;
    private Resolution[] resolutions;
    private CanvasGroup _canvasGroup;

    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        //Events
        //Button settings
        _settingsbutton.onClick.AddListener(ToggleSettings);
        //VSync
        _vsyncToggle.onValueChanged.AddListener(SetVSync);
        //No Shadows
        _noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        //Quality
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        //Resolutions
        _resolutionDrop.onValueChanged.AddListener(SetResolution);
        //Fullscreen
        _fullscreenToggle.onValueChanged.AddListener(FullScreen);
        //Brightness
        _brightnessDrop.onValueChanged.AddListener(SetTransparency);
        InitializeDropDownQuality();
        InitializeDropDownResolution();
    }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void ToggleSettings()
    {
        // Alterna el estado activo del panel de configuración
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
    }
    private void SetTransparency(float value)
    {
        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = value;
        }
    }
    private void SetVSync(bool stateOn)
    {
        if (stateOn)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
    private void SetNoShadows(bool stateOn)
    {
        if (stateOn)
            QualitySettings.shadows = ShadowQuality.Disable;
    }
    private void InitializeDropDownQuality()
    {
        List<string> options = new List<string>(QualitySettings.names);
        _qualityDrop.ClearOptions();
        _qualityDrop.AddOptions(options);

        // Configura el nivel de calidad actual como la opción seleccionada
        _qualityDrop.value = QualitySettings.GetQualityLevel();
        _qualityDrop.RefreshShownValue();
    }

    private void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
    private void InitializeDropDownResolution()
    {
        resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        foreach (Resolution resolution in resolutions)
        {
            options.Add(resolution.width + " x " + resolution.height);
        }

        _resolutionDrop.ClearOptions();
        _resolutionDrop.AddOptions(options);

        // Configura la resolución actual como la opción seleccionada
        Resolution currentResolution = Screen.currentResolution;
        int currentIndex = System.Array.FindIndex(resolutions, r => r.width == currentResolution.width && r.height == currentResolution.height);
        _resolutionDrop.value = currentIndex;
        _resolutionDrop.RefreshShownValue();
    }
    private void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void  FullScreen(bool fullscreen)
    {
        if (fullscreen)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;
    }
    #endregion
}
