using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Jetpack _jetpack;
    #endregion
    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal fly
        if (Input.GetAxis("Horizontal") < 0)
            _jetpack.FlyHorizontal(Jetpack.Direction.Left);
        if (Input.GetAxis("Horizontal") > 0)
            _jetpack.FlyHorizontal(Jetpack.Direction.Right);
        // Vertical fly
        if (Input.GetAxis("Vertical") > 0)
            _jetpack.FlyUp();
        else
            _jetpack.StopFlying();

    }
    #endregion
}
