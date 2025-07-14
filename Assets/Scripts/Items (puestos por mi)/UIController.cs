using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    #region Fields
    [SerializeField] private VitalSupport _vS;
    [SerializeField] private Slider _oxygenSlider;
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
        _oxygenSlider.value = _vS.Oxygen;
        _textSlider.text = ((int) _vS.transform.position.y).ToString();
    }
    #endregion
}
