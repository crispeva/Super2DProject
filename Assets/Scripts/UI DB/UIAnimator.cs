using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Properties
    #endregion

    #region Fields
    
    [SerializeField] Animator ButtonAnimator;
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
    }


    #endregion
    #region Public Methods
    public void SetSelected(bool isSelected)
    {
        ButtonAnimator.SetBool("IsSelected", isSelected);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonAnimator.SetBool("IsHighlighted", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ButtonAnimator.SetBool("IsHighlighted", false);
    }
    #endregion
    #region Private Methods

    #endregion
}
