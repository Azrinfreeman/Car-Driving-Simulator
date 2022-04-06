using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectiveController : MonoBehaviour
{
    [Header("Other Classes")]
    public LevelController level;


    [Header("Variables")]
    public TextMeshProUGUI objective;
    
    // Start is called before the first frame update
    void Start()
    {
        level = GetComponent<LevelController>();
        objective = GameObject.Find("objective").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.ParkingLevel)
        {
            objective.text = "Park the car on the highlighted area";
        }
    }
}
