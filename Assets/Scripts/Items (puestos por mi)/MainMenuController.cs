using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    #region Fields
    [SerializeField] Button _startGameButton;
    [SerializeField] Button _exitGameButton;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _startGameButton.onClick.AddListener(StartGame);
        _exitGameButton.onClick.AddListener(ExitGame);
    }
    #region Private Methods
    private void StartGame()
    {
        SceneManager.LoadScene("InGame");
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    #endregion
}
