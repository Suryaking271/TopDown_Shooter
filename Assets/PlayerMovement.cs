using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    private Player controller;
    public Vector2 mov_Input;
    public Vector2 aim_Input;
    public Vector3 movementDirection;
    int movementspeed = 5;


    private void Awake()
    {
       controller = new Player();

        
        controller.Character.Aim.performed += context => aim_Input = context.ReadValue<Vector2>();
        controller.Character.Aim.canceled += context => aim_Input = Vector2.zero;

        controller.Character.Movment.performed += context => mov_Input = context.ReadValue<Vector2>();
        controller.Character.Movment.canceled += context => mov_Input = Vector2.zero;
    }

    private void Start()
    {
        characterController = transform.GetComponent<CharacterController>();  
    }

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        movementDirection = new Vector3(mov_Input.x, 0, mov_Input.y);
        if ((movementDirection.magnitude > 0))
        {
            characterController.Move(movementDirection * Time.deltaTime * movementspeed);
        }
    }


    private void Shoot()
    {
        Debug.Log("Shoot");
    }
    public void OnEnable()
    {
        controller.Enable();
    }

    public void OnDisable()
    {
        controller.Disable();
    }
}
