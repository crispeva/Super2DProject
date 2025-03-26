using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]private GameObject portal;
    private bool isActive = true;
    //private bool isActive2 = true;
    private void Awake()
    {
        //portal = GetComponent<GameObject>();
    }
    void Start()
    {
        InvokeRepeating("TogglePortal", 0f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TogglePortal()
    {
       
            portal.SetActive(!portal.activeInHierarchy);
        
    }


}
