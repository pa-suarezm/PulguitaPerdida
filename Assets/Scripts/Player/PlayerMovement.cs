using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Input axis' names
    private static readonly string HorizontalAxisName = "Horizontal";
    private static readonly string VerticalAxisName = "Vertical";
    private static readonly string SprintAxisName = "Fire3";

    // Components
    private Rigidbody2D _rgb2d;

    // Aux variables
    private Vector2 _auxMovement;
    private float _horizontalAxisInput;
    private float _verticalAxisInput;
    private float _sprintAxisInput;
    private float _sqrMoveThresh;

    // Movement parameters
    private float _movementThreshold = 0.1f;
    private float _sprintThreshold = 0.5f;
    private float _speedMult = 6f;
    private float _sprintMult = 12f;

    void Start()
    {
        _rgb2d = GetComponent<Rigidbody2D>();

        _sqrMoveThresh = _movementThreshold * _movementThreshold;
    }

    private void FixedUpdate()
    {
        _auxMovement = Vector2.zero;

        _horizontalAxisInput = Input.GetAxis(HorizontalAxisName);
        _verticalAxisInput = Input.GetAxis(VerticalAxisName);

        _auxMovement.x = _horizontalAxisInput;
        _auxMovement.y = _verticalAxisInput;

        if (_auxMovement.SqrMagnitude() > _sqrMoveThresh)
        {
            _sprintAxisInput = Input.GetAxis(SprintAxisName);
            if (_sprintAxisInput > _sprintThreshold)
            {
                _auxMovement *= _sprintMult;
            }
            else
            {
                _auxMovement *= _speedMult;
            }

            _rgb2d.velocity = _auxMovement;
        }
        else
        {
            _rgb2d.velocity = Vector2.zero;
        }
    }
}
