using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float gravity = -9.81f;
    private float verticalVelocity;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        verticalVelocity += gravity * Time.deltaTime;
        Vector3 inputDir = new Vector3(InputController.Instance.moveVector.x,verticalVelocity,InputController.Instance.moveVector.y);
        Vector3 rotDir = new Vector3(InputController.Instance.moveVector.x,0,InputController.Instance.moveVector.y);
        moveDirection = inputDir * speed;
        characterController.Move(moveDirection * Time.deltaTime);
        if(rotDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,rotationSpeed);
        }
    }
}
