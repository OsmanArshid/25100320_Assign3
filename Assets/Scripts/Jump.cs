using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]                               
public class Jump : MonoBehaviour
{

    private CharacterController characterController;

    private Vector3 _playerVelocity;

    private bool _ground;
    [SerializeField] private float jumpHeight = 5.0f;

    private bool jumpPressed = false;

    private float gravity = -9.8f;

    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementJump();
    }

    void MovementJump()
    {
        _ground = characterController.isGrounded;

        if(_ground)
        {
        _playerVelocity.y = 0.0f;
        }

        if (jumpPressed && _ground){
        _playerVelocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity );
        }
    
    }

    
    void OnJump()
    {
        if (characterController.velocity.y == 0){
        jumpPressed = true;
    }
}
