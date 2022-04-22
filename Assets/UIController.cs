using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [Header("PauseMenuVariables")]
    public GameObject PausePanel;
    public GameObject UIPanel;
    public bool isPausing = false;
    public GameObject promptQuitPanel;


    [Header("Pedometer and hints")]
    //Pedometer and hints
    public GameObject SpeedometerPanel;
    public GameObject HintsPanel;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PausePanel = GameObject.Find("PauseMenus");
        UIPanel = GameObject.Find("UI");

        promptQuitPanel = GameObject.Find("Prompt");
        SpeedometerPanel = GameObject.Find("Speedometer");
        HintsPanel = GameObject.Find("InCar");

        PausePanel.SetActive(false);
        promptQuitPanel.SetActive(false);

    }

    void Update()
    {
        /*
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
        */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausing();

        }


    }

    public void ToMenu()
    {
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {

            yield return null;
        }
    }

    public void quitPrompting()
    {
        promptQuitPanel.SetActive(true);
    }
    public void closeQuitPrompting()
    {

        promptQuitPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void Pausing()
    {
        isPausing = !isPausing;

        if (isPausing)
        {
            PausePanel.SetActive(true);
            UIPanel.SetActive(false);
            promptQuitPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            PausePanel.SetActive(false);
            UIPanel.SetActive(true);

            promptQuitPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
