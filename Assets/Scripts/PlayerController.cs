using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] CharacterController controller;
    [SerializeField] private float speed = 12f;

    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    //public Animator anim;

    [SerializeField] Vector3 velocity;
    [SerializeField] bool isGrounded;

    public bool inCar = false;
    bool toggle = false;
    // Start is called before the first frame update
    private void Awake()
    {
        instance= this;
    }


    void Start()
    {

    }


    // Update is called once per frame
    private void Update()
    {
        if (!inCar)
        {
            UIController.instance.SpeedometerPanel.SetActive(false);
            UIController.instance.HintsPanel.SetActive(false);

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime); // for movement 

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime); // for gravity 
        }
        else
        {

            UIController.instance.SpeedometerPanel.SetActive(true);
           // UIController.instance.HintsPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T))
            {
                toggle = !toggle;
                if (toggle)
                {
                    UIController.instance.HintsPanel.SetActive(true);

                }
                else
                {
                    UIController.instance.HintsPanel.SetActive(false);

                }
            }
        }

    }

    public void ToggleCharacterController()
    {
        controller.enabled = !controller.enabled;
    }
}
