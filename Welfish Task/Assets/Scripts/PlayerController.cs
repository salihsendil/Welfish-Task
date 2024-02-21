using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;

    //Movement Variables
    Vector2 movementInput;
    Vector3 movementVector;
    Vector3 mousePos;
    Vector3 mouseWorldPos;
    [SerializeField] float moveSpeed = 5.0f;

    //Gravity Variables
    float gravity = -9.81f;
    float groundGravity = -0.05f;
    float gravityMultiplier = 3.0f;

    //Animation Variables
    int isWalkingHash;
    bool isWalkPressed;

    //Attack Variables
    bool isAttackPressed;
    bool isAttacking;


    //Getters and Setters
    public bool IsAttackPressed { get => isAttackPressed;}
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    private void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");

        playerInput.Movement.Move.started += OnMove;
        playerInput.Movement.Move.performed += OnMove;
        playerInput.Movement.Move.canceled += OnMove;
        playerInput.Attack.Attack.started += OnAttack;
        playerInput.Movement.Move.performed += OnAttack;
        playerInput.Attack.Attack.canceled += OnAttack;

    }

    void Update()
    {
        HandleRotation();
        HandleGravity();
        HandleMovement();
        HandleAnimation();

        //Debug.Log("input mouse pos: " + Input.mousePosition);
        //Debug.Log("mouseworldpos: " + mouseWorldPos);
    }

    private void HandleRotation()
    {
        mousePos = Input.mousePosition;
        mousePos.z = 250;
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, mouseWorldPos - Camera.main.transform.position, out hit, 300f)) {
            Debug.DrawRay(Camera.main.transform.position, mouseWorldPos - Camera.main.transform.position, Color.red);
            transform.LookAt(hit.point);
        }
    }

    private void HandleGravity()
    {
        if (characterController.isGrounded) {
            movementVector.y = groundGravity * gravityMultiplier;
        }
        else {
            movementVector.y = gravity * gravityMultiplier;
        }
    }

    private void HandleMovement()
    {
        movementVector.z = movementInput.y * moveSpeed;
        movementVector.x = movementInput.x * moveSpeed;
        movementVector *= Time.deltaTime;
        characterController.Move(movementVector);
        animator.SetFloat("Vertical", movementVector.z);
        animator.SetFloat("Horizontal", movementVector.x);

        if (movementVector.x != 0 || movementVector.z != 0) {
            isWalkPressed = true;
        }
        else {
            isWalkPressed = false;
        }

    }

    private void HandleAnimation()
    {
        if (isWalkPressed) {
            animator.SetBool(isWalkingHash, true);
        }
        if (!isWalkPressed) {
            animator.SetBool(isWalkingHash, false);
        }
        if (isAttackPressed && !isAttacking) {
            animator.SetTrigger("isAttacking");
        }
    }

    void OnMove(InputAction.CallbackContext callback)
    {
        movementInput = callback.ReadValue<Vector2>();
    }

    void OnAttack(InputAction.CallbackContext callback)
    {
        isAttackPressed = callback.ReadValueAsButton();
        isAttacking = false;
    }

    private void OnEnable()
    {
        playerInput.Movement.Enable();
        playerInput.Attack.Enable();
    }

    private void OnDisable()
    {
        playerInput.Movement.Disable();
        playerInput.Attack.Disable();
    }
}
