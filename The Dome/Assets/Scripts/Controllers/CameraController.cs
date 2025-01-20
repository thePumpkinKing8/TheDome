using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 _movement;
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.PlayerMoveEvent.AddListener(HandleMove);
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void HandleMove(Vector2 move)
    {
        _movement = new Vector3(move.x, move.y);  
    }

    private void Move()
    {
        _rb.velocity = (transform.up * (_movement.y * _speed))  + (transform.right * (_movement.x * _speed));
    }
}
