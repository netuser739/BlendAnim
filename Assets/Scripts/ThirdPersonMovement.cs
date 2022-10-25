using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private MovementCharacteristics _characteristics;

    //[SerializeField] private AudioSource _stepSound;

    private float vertical;

    private readonly string STR_VERICAL = "Vertical";

    private const float DISTANC_CAMERA_OFFSET = 5f;

    private CharacterController controller;
    private AudioSource stepSound;

    private Animator animator;

    private Vector3 direction;
    private Quaternion look;

    private Vector3 TargetRotate => _camera.forward * DISTANC_CAMERA_OFFSET;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        stepSound = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        Cursor.visible = _characteristics.CursorVisibility;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Rotation();
        Animation();
    }

    private void Movement()
    {
        if (controller.isGrounded)
        {
            vertical = Input.GetAxis(STR_VERICAL);

            direction = transform.TransformDirection(0f, 0f, vertical).normalized;
        }

        direction.y -= _characteristics.Gravity * Time.deltaTime;

        Vector3 dir = direction * _characteristics.MovementSpeed * Time.deltaTime;

        controller.Move(dir);

        if(vertical != 0f) stepSound.Play(); 
        else stepSound.Stop();

    }

    private void Rotation()
    {
        Vector3 target = TargetRotate;
        target.y = 0f;

        look = Quaternion.LookRotation(target);

        float speed = _characteristics.AngleSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, speed);
    }

    private void Animation()
    {
        if (Input.GetAxis(STR_VERICAL) != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }


        if (Input.GetKey(KeyCode.A)) animator.SetBool("Left", true);
        else animator.SetBool("Left", false);
        if (Input.GetKey(KeyCode.D)) animator.SetBool("Right", true);
        else animator.SetBool("Right", false);

    }
}
