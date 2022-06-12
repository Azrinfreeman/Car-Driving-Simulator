using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectiveController : MonoBehaviour
{
    public static ObjectiveController instance;
    [Header("Other Classes")]
    public LevelController level;


    [Header("Variables")]
    public TextMeshProUGUI objective;
    public List<bool>  mission;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Canvas").GetComponent<LevelController>();
        objective = GameObject.Find("objective").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame

    IEnumerator loadMission3()
    {

        yield return new WaitForSeconds(2f);
        objective.text = "Go to Burger Shop";
    }

    IEnumerator loadMission4()
    {
        yield return new WaitForSeconds(2f);
        objective.text = "Go to the Police Precinct";
    }
    void Update()
    {
        if (level.ParkingLevel)
        {
            objective.text = "Park the car on the highlighted area";
        }else if (level.CarMovementLevel)
        {
            if (mission[0])
            {

                objective.text = "Drive the car to the petrol gas station";
               
            }
            if (mission[1])
            {
               
                objective.text = "Park the car near the petrol gas and fill the gas tank";
               
            }
            if (mission[2])
            {

                objective.text = "Park the car near the petrol gas and fill the gas tank";

            }
            if (mission[3])
            {
                StartCoroutine(loadMission3());
                //objective.text = "Go to Burger Shop";

            }if (mission[4])
            {

                StartCoroutine(loadMission4());
                //objective.text = "Go to the Police Precinct";

            }
        }
    }
}
