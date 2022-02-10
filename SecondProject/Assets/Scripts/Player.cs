using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private float _speed = 5f;
    [SerializeField] private float _gravity = 1.3f;
    [SerializeField] private float _jumpHeight = 15.0f;
    private float _yVelocity;
    private bool _isJumped = false;
    private int _coin = 0;
    private UIManager _UiManager;
    [SerializeField] private int _lives = 3;
    private Vector3 startPos;
    // variable for player coins

    // Start is called before the first frame update
    void Start()
    {
        _UiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _controller = GetComponent<CharacterController>();

        _UiManager.UpdateLivesDisplay(_lives);

        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(HorizontalInput, 0, 0);
        Vector3 velocity = direction * _speed;

        
        if (_controller.isGrounded == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _isJumped = true;
            }
            
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (_isJumped == true)
                {
                    _yVelocity += _jumpHeight;
                    _isJumped = false;
                }
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -10)
        {
            _lives--;
            this.transform.position = startPos;
            _controller.enabled = false;
            _UiManager.UpdateLivesDisplay(_lives);
            StartCoroutine(ControllerRoutine(_controller));
            if (_lives < 1)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    IEnumerator ControllerRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }

    public void AddCoin()
    {
        _coin++;
        _UiManager.UpdateCoins(_coin);
    }

    
}
