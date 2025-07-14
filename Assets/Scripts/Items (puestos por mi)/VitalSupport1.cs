using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 

public class VitalSupport : MonoBehaviour
{
    
	public enum Direction
    {
        Left,
        Right
    }

    #region Properties
    public float Oxygen
    {
        get
        {
            return _oxygen;
        }
        set
        {
            _oxygen = Mathf.Clamp(value, 0, _maxOxygen);
        }
    }
    public bool Flying { get; set; }
    #endregion

    #region Fields							     
    private Rigidbody2D _target;
    [SerializeField] private float _maxOxygen;
    [SerializeField] private float _oxygenFlyingRatio;
    [SerializeField] private float _oxygenRegenerationRatio;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    [SerializeField] private float _oxygen;

    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _target = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Oxygen = _maxOxygen;
    }

    // Update is called once per physic frame
    void FixedUpdate()
    {
        if (Flying)
        {
            DoFly();
        }
        // Le quitamos el signo a la velocidad si es negativa
        // Luego si es menor de 0.1, consideramos que estamos parados y cargamos
        if(Mathf.Abs(_target.velocity.y) < 0.1f)
            Regenerate();
    }

    #endregion

    #region Public Methods
    public void FlyUp()
    {
        Flying = true;
    }
    public void StopFlying()
    {
        Flying = false;
    }

    public void Regenerate()
    {
        Oxygen += _oxygenRegenerationRatio;
    }

    public void AddOxygen(float oxygen)
    {
        Oxygen += oxygen;
    }

    public void FlyHorizontal(Direction flyDirection)
    {
        if (!Flying)
            return;

        if (flyDirection == Direction.Left)
            _target.AddForce(Vector2.left * _horizontalForce);
        else
            _target.AddForce(Vector2.right * _horizontalForce);
    }
    #endregion

    #region Private Methods
    private void DoFly()
    {
        if (Oxygen > 0)
        {
            _target.AddForce(Vector2.up * _flyForce);
            Oxygen -= _oxygenFlyingRatio;
        }
        else
            Flying = false;
    }
    #endregion
}
