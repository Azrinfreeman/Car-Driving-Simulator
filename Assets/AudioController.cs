using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Header("UI Sound effect")]
    public AudioSource button_click;


    // Start is called before the first frame update
    void Start()
    {
        button_click = GameObject.Find("button_click").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UI_Clicked()
    {
        button_click.Play();
    }
}
