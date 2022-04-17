using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingScript : MonoBehaviour
{

    public LevelController level;
    // Start is called before the first frame update
    void Start()
    {
        level = gameObject.GetComponent<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {

            Debug.Log("Touching the park");
        }
    }
}
