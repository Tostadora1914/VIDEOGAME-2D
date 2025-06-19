using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    #region Properties
    #endregion
    #region Fields
    [SerializeField] private float _minSpawnTime = 0.5f;
    [SerializeField] private float _maxSpawnTime = 4f;
    private float _nextSpawnTime = 5f;
    [SerializeField] private List<Item> _spawnlist;
    private float _cronoTime = 0f;
    #endregion
    #region Unity Callbacks
    #endregion
    #region Public Methods
    #endregion
    #region Private Methods
    private void SpawnItem()
    {
        // Random objetct from a list

        int index = Random.Range(0, _spawnlist.Count);
        // Random horizontal position

        float xPos = Random.Range(-7f, 7f);
        Vector2 itemPosition = new Vector2(xPos, transform.position.y);
        // Instantiation

        Item newItem = Instantiate(_spawnlist[index], itemPosition, Quaternion.identity);
        // Add rotation force

        float torqueForce = Random.Range(-70f, 70f);
        newItem.GetComponent<Rigidbody2D>().AddTorque(torqueForce);
        // Dificulty progression
        if(_maxSpawnTime > _minSpawnTime)
        {
            _maxSpawnTime -= 0.1f;
        }
        
    }
    private void ResetTime()
    {
        _cronoTime = 0;
        _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        _cronoTime += Time.deltaTime;
        if (_cronoTime > _nextSpawnTime)
        {
            ResetTime();
            SpawnItem(); 
        }
    }
}
