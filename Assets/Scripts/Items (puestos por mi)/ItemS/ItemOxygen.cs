using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOxygen : Item
{
    const float OXYGEN_HEAL = 25;
    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            VitalSupport vitalSupport = collision.gameObject.GetComponent<VitalSupport>();
            vitalSupport.AddOxygen(OXYGEN_HEAL);
            Recolected();
        }
        if (collision.gameObject.tag == "Ground")
        Destroy(gameObject);

    }
    #endregion
}
