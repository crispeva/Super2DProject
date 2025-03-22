using UnityEngine;
using System;

public class Item : MonoBehaviour, IRecolectable
{
	#region Enums
	public enum ItemTypes
	{
		None,
		GoodBall,
		BadBall,
		GoodEnergy,
		BadEnergy
	}
	#endregion

	#region Properties
	[field: SerializeField] public ItemTypes Type { get; set; }
	#endregion

	#region Fields
	[SerializeField] private GameObject _particles;
	private Player _player;
    #endregion
    #region Unity Callbacks
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    #endregion
    #region Public Methods
    public virtual void BadRecolected()
	{
		Destroy(gameObject);
		CreateParticles();
        _player.TakeHit();


    }
    public virtual void GoodRecolected()
    {
        Destroy(gameObject);
        CreateParticles();
    }
    public virtual void DestroyInGround()
    {
        Destroy(gameObject);
        
    }
    #endregion

    #region Private Methods
    private void CreateParticles()
	{
		Instantiate(_particles, transform.position, Quaternion.identity);
	}
	#endregion
}
