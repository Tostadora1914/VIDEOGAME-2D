using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    #region Unity Callbacks
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("MainMenu");
    }
    #endregion
}
