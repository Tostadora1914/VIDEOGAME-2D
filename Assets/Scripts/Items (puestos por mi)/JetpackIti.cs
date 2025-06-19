using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 

public class Jetpack : MonoBehaviour
{
    
	public enum Direction
    {
        Left,
        Right
    }

    #region Properties
    public float Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = Mathf.Clamp(value, 0, _maxEnergy);
        }
    }
    public bool Flying { get; set; }
    #endregion

    #region Fields							     
    private Rigidbody2D _target;
    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    [SerializeField] private float _energy;

    #endregion

    #region Unity Callbacks
    private void Awake()
    {
        _target = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Energy = _maxEnergy;
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
        Energy += _energyRegenerationRatio;
    }

    public void AddEnergy(float energy)
    {
        Energy += energy;
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
        if (Energy > 0)
        {
            _target.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
        }
        else
            Flying = false;
    }
    #endregion
}
