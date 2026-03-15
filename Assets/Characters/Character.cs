using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{

    public float Speed = 5f;
    public float sensitivity = 2.0f;
    public float rotationSpeed = 20f;
    public TMP_InputField inputField;

    private CharacterController characterController;
    private bool isTyping;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isTyping = inputField.isFocused;

        if (true)
        {

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            characterController.Move(move * Speed * Time.deltaTime);

            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(-90f, 0f, 0f)), Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(90f, 0f, 0f)), Time.deltaTime * rotationSpeed);

            }

            if (Input.GetAxis("Vertical") < 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0f, 0f, -180f)), Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0f, 0f, 180f)), Time.deltaTime * rotationSpeed);
            }
        }
        else
        {
            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.constraints = RigidbodyConstraints.FreezePosition;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            //rb.linearVelocity = new Vector3(0, 0, 0);
        }
    }
}
