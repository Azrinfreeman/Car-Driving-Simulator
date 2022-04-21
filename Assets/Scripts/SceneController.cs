using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneController : MonoBehaviour
{


    [Header("LoadingScreenVariables")]
    [SerializeField] public Slider sliderProgress;
    [SerializeField] GameObject LoadingMenu;
    //[SerializeField] GameObject CurrentPage;

    [Header("For loading screen fade")]
    [SerializeField] CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        sliderProgress = GameObject.Find("Slider").GetComponent<Slider>();
        LoadingMenu = GameObject.Find("LoadingMenu");

    
        LoadingMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadCarMovementLessonLevel()
    {
        LoadingMenu.SetActive(true);
        StartCoroutine(LoadCarMovementScene());
    }



    public void LoadParkingLessonScene()
    {
        LoadingMenu.SetActive(true);
      //  CurrentPage.SetActive(false);
        StartCoroutine(LoadCarParkingScene());
        //  StartCoroutine(FadeLoadingScreen(2.2f));

    }

    IEnumerator LoadHandBrakeScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CarHandBrakeLesson");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            sliderProgress.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            yield return null;
        }
    }
    IEnumerator LoadCarMovementScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CarMovementLesson");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            sliderProgress.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            yield return null;
        }
    }

    IEnumerator LoadCarParkingScene()
    {



        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CarParkingLesson");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            sliderProgress.value = Mathf.Clamp01(asyncLoad.progress / 0.9f);

            yield return null;
        }
    }

    //fading screen loading  
    /*
    IEnumerator FadeLoadingScreen(float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;
        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, 1, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }
    */



}
