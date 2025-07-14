using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMONOXIDODECARBONO : Item, IRecolectable
{
    private Animator _anim;
    const float MONOXIDODECARBONO_DAMAGE = -20;
    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        Destroy(gameObject);
        if (collision.gameObject.tag == "Player")
        {
            VitalSupport vitalSupport = collision.gameObject.GetComponent<VitalSupport>();
            vitalSupport.AddOxygen(MONOXIDODECARBONO_DAMAGE);
            Recolected();
        }

        #endregion
    }
}
