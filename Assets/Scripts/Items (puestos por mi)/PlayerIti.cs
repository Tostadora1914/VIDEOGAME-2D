using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    #region Properties

    private Animator _anim;
    #endregion
    #region Fields
    [SerializeField] private VitalSupport _vS;
    #endregion
    #region Unity Callbacks
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NoSe")
        {
            _anim.SetTrigger("Damage");
        }
    }
    void Update()
    {
        _anim.SetBool("Flying", _vS.Flying);
    }
    #endregion
    #region Public Methods

    #endregion
    #region Private Methods

    #endregion

}
