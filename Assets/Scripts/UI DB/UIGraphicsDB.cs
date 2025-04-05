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
    [SerializeField] Toggle _noShadowToggle;
    [SerializeField] TMP_Dropdown _qualityDrop;
    [SerializeField] TMP_Dropdown _resolutionDrop;
    Resolution[] resolution;

    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        //Events
        //Button click
        _settingsbutton.onClick.AddListener(ToggleSettings);
        _vsyncToggle.onValueChanged.AddListener(SetVSync);
        _noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        _resolutionDrop.onValueChanged.AddListener(SetResolution);
        InitializeDropDownQuality();
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
    private void SetResolution(int index)
    {
        // Aquí puedes implementar la lógica para cambiar la resolución
        // dependiendo de la opción seleccionada en el dropdown.
        // Por ejemplo:
        Resolution [] resolution = resolutions[index];
        Screen.SetResolution(_resolutionDrop.[index].width, resolutions[index].height, Screen.fullScreen);
    }
    #endregion
}
