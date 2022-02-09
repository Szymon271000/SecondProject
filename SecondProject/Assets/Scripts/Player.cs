using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // variable for player coins

    // Start is called before the first frame update
    void Start()
    {
        _UiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _controller = GetComponent<CharacterController>();
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
    }

    public void AddCoin()
    {
        _coin++;
        _UiManager.UpdateCoins(_coin);
    }
}
