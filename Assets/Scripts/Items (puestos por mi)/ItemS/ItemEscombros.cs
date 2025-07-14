using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEscombros : Item 
{
    const float ESCOMBROS_FORCE = 10000;
    const float ESCOMBROS_DOWN_POS = 2.5f;
    #region Unity Callbacks
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            VitalSupport vitalSupport = collision.gameObject.GetComponent<VitalSupport>();
            // Efecto
            if (vitalSupport.Flying)
                vitalSupport.GetComponent<Rigidbody2D>().AddForce(Vector2.down * ESCOMBROS_FORCE);
            else
                if (vitalSupport.transform.position.y > 1) // Para evitar que nos unda en el suelo
                vitalSupport.transform.Translate(Vector2.down * ESCOMBROS_DOWN_POS);
            Recolected();
        }
        if (collision.gameObject.tag == "Ground")
            Destroy(gameObject);


    }
    #endregion
}
