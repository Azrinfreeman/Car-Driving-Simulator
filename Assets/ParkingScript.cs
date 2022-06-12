using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ParkingScript : MonoBehaviour
{
    [Header("Other Classes")]
    public ObjectiveController controller;
 

    [Header("Variables")]
    public TextMeshProUGUI EventText;
    public LevelController level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Canvas").GetComponent<LevelController>();
        EventText = GameObject.Find("EventText").GetComponent<TextMeshProUGUI>();
        controller = GameObject.Find("Objectives").GetComponent<ObjectiveController>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            if (level.CarMovementLevel)
            {

                if (controller.mission[0] && WheelController.instance.CMMission[0])
                {
                    Debug.Log("New mission1");
                    controller.mission[0] = false;
                    controller.mission[1] = true;
                }

                if (controller.mission[1] && WheelController.instance.CMMission[1])
                {

                    controller.mission[1] = false;
                    controller.mission[2] = true;
                }
                if (controller.mission[2] && WheelController.instance.CMMission[2])
                {
                    Debug.Log("Missio 2 ");
                    EventText.text = "Press F to refuel the gas for the car";
                    if (Input.GetKeyDown(KeyCode.F))
                    {

                        controller.mission[2] = false;
                        controller.mission[3] = true;
                        EventText.text = "";
                    }
                }if (controller.mission[3] && WheelController.instance.CMMission[4])
                {
                    Debug.Log("Missio 3 ");
                    EventText.text = "Press F to Pin the checkpoint";
                    if (Input.GetKeyDown(KeyCode.F))
                    {

                        controller.mission[3] = false;
                        controller.mission[4] = true;
                        EventText.text = "";
                    }
                }if (controller.mission[4] && WheelController.instance.CMMission[5])
                {
                    Debug.Log("Missio 4 ");
                    EventText.text = "Press F to Pin the checkpoint";
                    if (Input.GetKeyDown(KeyCode.F))
                    {

                        controller.mission[4] = false;
                        controller.mission[5] = true;
                        EventText.text = "";
                    }
                }
                
            };
        }
    }
}
