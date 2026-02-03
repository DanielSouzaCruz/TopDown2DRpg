using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private float initialSpeed;
    private Vector2 _direction;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;
    [HideInInspector] public int handlingObject;

    private Rigidbody2D rig;
    private PlayerItems playerItems;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }

    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }

    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging { get => _isDigging; set => _isDigging = value; }
    public bool IsWatering { get => _isWatering; set => _isWatering = value; }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();
        initialSpeed = speed;
    }

    private void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObject = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                handlingObject = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                handlingObject = 2;
            }

            OnInput();
            OnRun();
            OnRoll();
            OnCut();
            OnDig();
            OnWatering();
        }
        
    }

    private void FixedUpdate()
    {
        if (!isPaused)
        {
            OnMove();
        }
        
    }

    #region Movement

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRoll()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
        }
    }

    void OnCut()
    {
        if (handlingObject == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsCutting = true;
                speed = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                IsCutting = false;
                speed = initialSpeed;
            }
        }

    }

    void OnDig()
    {
        if (handlingObject == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsDigging = true;
                speed = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                IsDigging = false;
                speed = initialSpeed;
            }
        }

    }

    void OnWatering()
    {
        if (handlingObject == 2)
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentWater > 0)
            {
                IsWatering = true;
                speed = 0;
            }
            if (Input.GetMouseButtonUp(0) || playerItems.currentWater < 0)
            {
                IsWatering = false;
                speed = initialSpeed;
            }

            if (IsWatering)
            {
                playerItems.currentWater -= 0.01f;
            }
        }

    }

    #endregion
}
