
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System; 

public class UISettings : MonoBehaviour
{
    #region Properties
    #endregion
    #region Fields
    [SerializeField] Button _closeButton;
    [SerializeField] TMP_Dropdown _qualityDrop;
    [SerializeField] Toggle _vsyncToggle;
    [SerializeField] Toggle _fullScreenToggle;
    [SerializeField] Toggle _noShadowToggle;
    [SerializeField] Toggle _softShadowToggle;
    [SerializeField] Toggle _hardShadowToggle;
    [SerializeField] Slider _particleResolutionSlider;
    [SerializeField] GameObject _lateralPanel;
    [SerializeField] GameObject _settingsPanel;
    [SerializeField] Button _settingsButton;
    #endregion
    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
        // Events
        // Button Click
        InitializeDropDownQuality();

        // Events
        // Button Click
        InitializeDropDownQuality();
        _settingsButton.onClick.AddListener(OpenSettingsPanel);
        _closeButton.onClick.AddListener(CloseSettings);
        _qualityDrop.onValueChanged.AddListener(SetQuality);
        _vsyncToggle.onValueChanged.AddListener(SetVSync);
        // Full Screen
        //Screen.fullScreen = true;
        _particleResolutionSlider.onValueChanged.AddListener(SetParticleResolution);
        _noShadowToggle.onValueChanged.AddListener(SetNoShadows);
        _softShadowToggle.onValueChanged.AddListener(SetSoftShadows);
    }
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    private void SetSoftShadows(bool stateOn)
    {
        if (stateOn)
        {
            QualitySettings.shadows = ShadowQuality.All;// Soft
            //QualitySettings.shadows = ShadowsQuality.HardOnly;// Hard
        }
    }
    private void SetNoShadows(bool stateOn)
    {
        if (stateOn)
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
    }
    void OpenSettingsPanel()
    {
        _lateralPanel.SetActive(false); // Cierra el lateral
        _settingsPanel.SetActive(true); // Abre Settings
    }
    private void SetParticleResolution(float level)
    {
        QualitySettings.particleRaycastBudget = (int)level;
    }
    private void SetVSync(bool stateOn)
    {
        if (stateOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        
    }
    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }
    public void CloseLateralPanel()
    {
        _lateralPanel.SetActive(false);
    }
    private void InitializeDropDownQuality()
    {
        List<string> options = new List<string>(QualitySettings.names);
        _qualityDrop.ClearOptions();
        _qualityDrop.AddOptions(options);

        // Configura el nivel de calidad actual como la opción seleccionada
        _qualityDrop.value = QualitySettings.GetQualityLevel();
        _qualityDrop.RefreshShownValue();

    }
    private void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, true);
    }
    #endregion
}
