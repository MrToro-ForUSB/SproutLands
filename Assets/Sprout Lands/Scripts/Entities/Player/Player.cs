using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Player : Entity
{
    // —————————— propierties
    public Vector2 Velocity
    {
        get => Vector3.Normalize(velocity);
    }
    public Vector2 LastVelocity
    {
        get => Vector3.Normalize(lastVelocity);
    }
    
    

    // —————————— fields
    private Rigidbody2D _rigidbody2D;
    
    private Vector2 inputs = Vector2.zero;

    [TitleGroup("Movement")]
    private bool canMove = true;
    private Vector2 velocity = Vector2.zero;
    private Vector2 lastVelocity = Vector2.zero;
    [SerializeField] private float speedMult = 5;


    // —————————— unity methods
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        // Actualizamos la posición del jugador recuperandola de memoria
        Vector2 position = new(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"));
        transform.position = position;
        
        GameManager.Instance.OnSave.AddListener(Save);
    }
    private void Update()
    {
        GetInputs();
        TryMove();
    }


    
    // —————————— class methods
    private void GetInputs()
    {
        inputs = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void TryMove()
    {
        if (!canMove)
            return;
        
        Move();
    }
    protected override void Move()
    {
        if (inputs.magnitude != 0)
        {
            lastVelocity = velocity;
        }
        
        velocity = inputs * speedMult;
        _rigidbody2D.velocity = velocity;
    }
    protected override void DeleteEntity(params object[] arguments)
    {
        
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
    }
}
