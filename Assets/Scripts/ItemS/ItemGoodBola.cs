using UnityEngine;
using System;

public class ItemGoodBola : Item
{
	#region Contants

	const float POSITIVE_HEAL = 100;
	#endregion
	#region Unity Callbacks
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
            DestroyInGround();

		if (collision.gameObject.tag == "Player")
		{
			Jetpack jetpack = collision.gameObject.GetComponent<Jetpack>();			
			jetpack.AddEnergy(POSITIVE_HEAL);
			Recolected();
		}
	}
	#endregion

}
