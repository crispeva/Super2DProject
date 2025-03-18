using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Jetpack _jetpack;
	[SerializeField] private Player _player;
    [SerializeField] private float _velocityPlayer;
    #endregion

    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        _velocityPlayer= 6;
    }

    // Update is called once per frame
    void Update()
    {
		//Horizontal Fly
		if (Input.GetAxis("Horizontal") < 0)
			_jetpack.FlyHorizontal(Jetpack.Direction.Left);
			
        if (Input.GetAxis("Horizontal") > 0)
		{
            _jetpack.FlyHorizontal(Jetpack.Direction.Right);
            
        }

        //Vertical Fly
        if (Input.GetAxis("Vertical") > 0)
        {
            _jetpack.FlyUp();
        }


        else
        {
            _jetpack.StopFlying();
        }


    }
    #endregion

    #region Public Methods
    public bool ControllPlayerLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _player.transform.Translate(Vector3.left * Time.deltaTime * _velocityPlayer);
            return true;
        }

            return false;
        
    }
    public bool ControllPlayerRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _player.transform.Translate(Vector3.right * Time.deltaTime * _velocityPlayer);
            return true;
        }
            return false;


    }
    #endregion

    #region Private Methods
    #endregion
}
