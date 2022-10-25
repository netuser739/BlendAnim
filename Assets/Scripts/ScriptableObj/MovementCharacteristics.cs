using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristics", menuName = "Movement / MovementCharacteristics", order = 1)]
public class MovementCharacteristics : ScriptableObject
{
    [SerializeField] private bool _cursorVisibility = true;

    [SerializeField] private float _movementSpeed = 1f;

    [SerializeField] private float _angleSpeed = 150f;

    [SerializeField] private float _gravity = 10f;

    public float MovementSpeed => _movementSpeed;

    public float AngleSpeed => _angleSpeed;

    public float Gravity => _gravity;

    public bool CursorVisibility => _cursorVisibility;


}
