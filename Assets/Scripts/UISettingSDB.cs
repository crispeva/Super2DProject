using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingSDB : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    [SerializeField] Button _closeButton;
 

    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        //Events
        //Button click
        _closeButton.onClick.AddListener(CloseSettings);


    }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
