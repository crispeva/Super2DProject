using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIVolumenDB : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] Slider _sliderVolumen;
    [SerializeField] Toggle _muteToggle;
 

    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        _sliderVolumen.onValueChanged.AddListener(SetVolume);
        _muteToggle.onValueChanged.AddListener(SetMute);
        _sliderVolumen.value = AudioListener.volume;
        _sliderVolumen.maxValue = 1f;
    }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void SetVolume(float volume)
    {
        // Ajusta el volumen global del audio
        AudioListener.volume = volume;
        if(volume == 0)
        {
            _muteToggle.isOn = true;
        }
        else
        {
            _muteToggle.isOn = false;
        }
    }
    private void SetMute(bool isMuted)
    {
        // Ajusta el volumen global del audio

        // Ajusta el volumen global del audio
        if (isMuted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = _sliderVolumen.value;
        }
    }
    #endregion
}
