using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImputController : MonoBehaviour
{
    #region Fields
    [SerializeField] private VitalSupport _vS;
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
        {
            _vS.FlyHorizontal(VitalSupport.Direction.Left);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            _vS.FlyHorizontal(VitalSupport.Direction.Right);
        }
        // Vertical fly
        if (Input.GetAxis("Vertical") > 0)
        {
            _vS.FlyUp();
        }
        else
        {
            _vS.StopFlying();
        }


    }
            #endregion
}
   
    

