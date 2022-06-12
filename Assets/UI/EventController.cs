using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EventController : MonoBehaviour
{
    // Start is called before the first frame update
    //Entering the car 
    [Header("For Car Entering Event")]
    public GameObject CarPromptTextObject;
    bool isCarPromptShow = false;



    //For player position;
    public Transform PlayerPosition;
    public Transform PlayerInCarPosition;
    public Transform PlayerOutCarPosition;
    public bool toggle =false;
    void Start()
    {
        PlayerPosition = GameObject.Find("Player").transform;
        PlayerInCarPosition = GameObject.Find("PlayerPlaceholderCoordinate").transform;
        CarPromptTextObject = GameObject.Find("CarPrompt");
        PlayerOutCarPosition = GameObject.Find("PlayerOutPosition").transform;
        CarPromptTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isCarPromptShow)
        {
            
            if (Input.GetKeyDown(KeyCode.E) && WheelController.instance.rb.velocity.x < 2f)
            {
                toggle = !toggle;
                if (toggle)
                {
                    PlayerController.instance.ToggleCharacterController();
                    PlayerPosition.transform.position = PlayerInCarPosition.transform.position;
                    Debug.Log("E is pressed");

                    // PlayerController.instance.ToggleCharacterController();
                    PlayerController.instance.inCar = true;
                    CarPromptTextObject.SetActive(false);

                }
                else
                {
                   
                    PlayerPosition.transform.position = PlayerOutCarPosition.transform.position;
                    Debug.Log("E is pressed");

                    // PlayerController.instance.ToggleCharacterController();
                    PlayerController.instance.inCar = false;
                    CarPromptTextObject.SetActive(false);
                    PlayerController.instance.ToggleCharacterController();
                    WheelController.instance.isEngineStart = false;
                    WheelController.instance.isPlayerRide = false;

                }
            }
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            CarPromptTextObject.SetActive(true);
            isCarPromptShow = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

           
            CarPromptTextObject.SetActive(false);
            isCarPromptShow = false;
        }
    }
}
