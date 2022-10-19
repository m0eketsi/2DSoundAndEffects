using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 10;
    private PlayerContoller _playerScripts;
    // Start is called before the first frame update
    void Start()
    {
        _playerScripts = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerScripts.isGameOver == false)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }
}
