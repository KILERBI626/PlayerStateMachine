using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _input;

    public StateMachine _machine;
    public Rigidbody _playerRigidbody;

    [Header("Direction Information")]
    [SerializeField] private Vector3 _jumpDirection;
    [SerializeField] private Vector3 _movementDirection;

    [Header("Crouch Menu")]
    [SerializeField] private int _crouchSpeed = 3;
    [SerializeField] private bool _isCrouchPressed = false;

    [Header("Jump Menu")]
    [SerializeField] private bool _isJumpPressed;

    [Header("Walk Menu")]
    [SerializeField] private int _walkSpeed = 5;

    [Header("Run Menu")]
    [SerializeField] private int _runSpeed = 10;
    [SerializeField] private bool _isRunPressed = false;

    /// <summary>
    /// Геттеры Сеттеры
    /// </summary>
 
    public int CrouchSpeed { get { return _crouchSpeed; }}
    public int RunSpeed { get { return _runSpeed; }}
    public int WalkSpeed { get { return _walkSpeed; }}
    public bool IsRunPressed { get { return _isRunPressed; }}
    public bool IsCrouchPressed { get { return _isCrouchPressed; }}
    public bool IsJumpPressed {  get { return _isJumpPressed; }}
    public Vector3 JumpDirection { get { return _jumpDirection; }}
    public Vector3 MovementDirection { get { return _movementDirection; }}


    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody>();

        _machine = new StateMachine();
        _machine.Initialize(new IdleState(this));
        
        // настраиваем колбеки 
        _input = new PlayerInput();
        _input.PlayerController.Move.started += OnMovementInput;
        _input.PlayerController.Move.performed += OnMovementInput;
        _input.PlayerController.Move.canceled += OnMovementInput;
        _input.PlayerController.Run.started += OnRunInput;
        _input.PlayerController.Run.canceled += OnRunInput;
        _input.PlayerController.Crouch.started += OnCrouchInput;
        _input.PlayerController.Crouch.canceled += OnCrouchInput;

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _machine.UpdateState();
    }

    //private void HandleRotation()
    //{
    //    Vector3 positionToLookAt = _movementDirection;
    //    Quaternion currentRotation = transform.rotation;
    //    Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
    //    transform.rotation = Quaternion.Slerp(targetRotation, currentRotation, 15f * Time.deltaTime);
    //}

    private void HandleJump()
    {
        if (_playerRigidbody.velocity.y > 0)
        {

        }
    }

    private void OnMovementInput(InputAction.CallbackContext context)
    {
        _movementDirection = context.ReadValue<Vector3>();
    }

    private void OnRunInput(InputAction.CallbackContext context)
    {
        _isRunPressed = context.ReadValueAsButton();
    }

    private void OnJumpInput(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
    }

    private void OnCrouchInput(InputAction.CallbackContext context)
    {
        _isCrouchPressed = context.ReadValueAsButton();
    }

    private void OnEnable()
    {
        _input.PlayerController.Enable();
    }

    private void OnDisable()
    {
        _input.PlayerController.Disable();
    }
}