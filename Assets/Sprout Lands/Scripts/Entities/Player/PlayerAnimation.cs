using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // —————————— fields
    private Player _player;
    private Animator _animator;


    
    // —————————— unity methods
    private void Start()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _animator.SetFloat("velocityX", _player.Velocity.x);
        _animator.SetFloat("velocityY", _player.Velocity.y);
        _animator.SetFloat("lastVelocityX", _player.LastVelocity.x);
        _animator.SetFloat("lastVelocityY", _player.LastVelocity.y);
    }
}
