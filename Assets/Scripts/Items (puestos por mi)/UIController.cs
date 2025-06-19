using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Fields
    [SerializeField] private Jetpack _jetpack;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private TextMeshProUGUI _textSlider;
    #endregion
    #region Unity Callbacks
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _energySlider.value = _jetpack.Energy;
        _textSlider.text = ((int) _jetpack.transform.position.y).ToString();
    }
    #endregion
}
