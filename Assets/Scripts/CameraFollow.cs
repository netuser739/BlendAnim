using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField][Range(0f, 2f)] private float _angleSpeed = 1f;
    [SerializeField] private Transform _target;

    private float _angle;

    // Start is called before the first frame update
    void Start()
    {
        _angle = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) _angle += _angleSpeed;
        if (Input.GetKey(KeyCode.A)) _angle -= _angleSpeed;

        transform.position = _target.position;
        transform.rotation = Quaternion.Euler(0f, _angle, 0f);

    }
}
