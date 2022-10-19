using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 _spawnPos = new Vector3(17, -4.25f, 0);
    private float _startDelay = 2;
    private float _repeatRate = 2;
    private PlayerContoller _playerScript;

    // Start is called before the first frame update
    void Start()
    {
        _playerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
       InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    void SpawnObstacle()
    {
        if(_playerScript.isGameOver == false)
        {
        Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}