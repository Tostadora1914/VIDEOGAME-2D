using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IRecolectable
{
    [SerializeField] private Jetpack jetpack;
    
    #region Fields
    [SerializeField] private GameObject _particles;
    #endregion
    #region Enums
    public enum ItemTypes
    {
        None,
        NoSe,
        ErrorCode,
        PositiveWords
    }
    #endregion
    #region Properties
    [field: SerializeField] public ItemTypes Type {  get; set; }
    #endregion
    #region Fields
    #endregion
    #region Public Methods
    public void Recolected()
    {
        Destroy(gameObject);
        CreateParticles();
    }
    #endregion
    #region Private Methods
    public void CreateParticles()
    {
        Instantiate(_particles, transform.position, Quaternion.identity);
    }
    #endregion
}
