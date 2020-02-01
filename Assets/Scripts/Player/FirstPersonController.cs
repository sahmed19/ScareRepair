using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{

    [System.Serializable]
    public class MovementVariables
    {
        public float speed = 10f;
        public float smoothing = 3f;
        public Vector2 motionInput;
        public Vector3 velocityVector;
        public bool crouching;
        public float crouchingSpeedMultiplier = .5f;
    }

    [System.Serializable]
    public class TurningVariables
    {
        public Vector2 mouseInput;
        public Vector2 viewAngle;
        public float sensitivity = 1.0f;
        public bool invertY = false;
        public float cameraHeight = 1.0f;
        public AnimationCurve crouchCurve;

        public Vector3 headbob;

    }

    [SerializeField] private MovementVariables movementVariables;
    [SerializeField] private TurningVariables turningVariables;


    public Camera fpCamera;

    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        GatherInput();
        Locomotion();
        TurningAndCamera();
    }

    private void GatherInput()
    {
        movementVariables.motionInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        turningVariables.mouseInput = new Vector2(Input.GetAxisRaw("MouseX"), (turningVariables.invertY ? 1.0f : -1.0f) * Input.GetAxisRaw("MouseY"));
        if (Input.GetButtonDown("Crouch")) {
            movementVariables.crouching = !movementVariables.crouching;
        }
    }

    private void Locomotion()
    {
        Vector3 targetVelocity =
            (movementVariables.motionInput.x * transform.right + movementVariables.motionInput.y * transform.forward)
            * movementVariables.speed * (movementVariables.crouching ? movementVariables.crouchingSpeedMultiplier : 1.0f);

        movementVariables.velocityVector =
            Vector3.Lerp(movementVariables.velocityVector, targetVelocity, movementVariables.smoothing * Time.deltaTime);

        characterController.SimpleMove(movementVariables.velocityVector);
    }

    private void TurningAndCamera()
    {
        turningVariables.viewAngle += turningVariables.mouseInput * turningVariables.sensitivity;
        transform.localRotation = Quaternion.Euler(Vector3.up * turningVariables.viewAngle.x);
        fpCamera.transform.localRotation = Quaternion.Euler(Vector3.right * turningVariables.viewAngle.y);
        turningVariables.cameraHeight = Mathf.Lerp(turningVariables.cameraHeight,
            (movementVariables.crouching ? 0.0f : 1.0f), Time.deltaTime * 7.0f);

        fpCamera.transform.localPosition = Vector3.up * turningVariables.crouchCurve.Evaluate(turningVariables.cameraHeight);

        Vector3 targetBob = new Vector3(Mathf.Sin(Time.time * 7f), -Mathf.Abs(Mathf.Cos(.2f + Time.time * 7f)), 0f) * .1f;
        targetBob *= movementVariables.motionInput.sqrMagnitude;
        if(movementVariables.crouching) { targetBob *= .5f; }


        turningVariables.headbob = Vector3.Lerp(turningVariables.headbob, targetBob, 15.0f * Time.deltaTime);

        fpCamera.transform.localPosition += turningVariables.headbob;

    }

}
