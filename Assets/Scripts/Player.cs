using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
	#region Properties
	#endregion

	#region Fields
	[SerializeField] private Jetpack _jetpack;
    private Animator _anim;
    private InputController _controller;
    #endregion

    #region Unity Callbacks
    private void Awake()
	{
		_anim = GetComponent<Animator>();
        _controller = GetComponent<InputController>();

    }

    // Update is called once per frame
    void Update()
    {
		_anim.SetBool("Flying", _jetpack.Flying);
        _anim.SetBool("FlyingLeft", _jetpack.FlyingLeft);
        _anim.SetBool("RunLeft", _controller.ControllPlayerLeft());
        _anim.SetBool("RunRight", _controller.ControllPlayerRight());
    }
	#endregion

	#region Public Methods
	public void TakeHit()
	{
        _anim.SetTrigger("Hit");
    }
	#endregion

	#region Private Methods
	#endregion   
}
