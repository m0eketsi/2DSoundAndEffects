using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public float jumpForce = 10;
    private Rigidbody2D _playerRB;
    public bool isOnGround = false;
    public bool isGameOver = false;
    private Animator _playerAnim;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    private AudioSource _playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround && isGameOver == false)
        {
            _playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            _playerAnim.SetBool("isOnGround", false);
            _playerAudio.PlayOneShot(jumpClip, 1f);
        }
    }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
                _playerAnim.SetBool("isOnGround", isOnGround);
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("Obstacle"))
            {
                isGameOver = true;
               _playerAnim.SetBool("IsHit", isGameOver);
               _playerAudio.PlayOneShot(crashClip, 1f);
            }
        }
         IEnumerator ExampleCoroutine()
    {
      if (isGameOver)
      {
          yield return new WaitForSeconds(0.667f);
         _playerAnim.SetBool("GameOver", true);
      }
    }
 }
