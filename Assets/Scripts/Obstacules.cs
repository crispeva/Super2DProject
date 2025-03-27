using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacules : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]private GameObject portal;
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
