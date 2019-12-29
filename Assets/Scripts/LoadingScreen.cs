using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instace;

    [SerializeField]
    private GameObject Loading_Bar_Holder;
    [SerializeField]
    private Image Loading_Bar_Progress;

    private float progress_Value = 1.1f;
    public float progress_Multiple_1 = 0.5f;
    public float progress_Multiple_2 = 0.07f;
    public float Load_Level_Time=2f;


    void Awake()
    {
        MakeSingleton();
    }
    // Use this for initialization
    void Start()
    {
        StartCoroutine(LoadingSomeLevel());
    }

    void MakeSingleton()
    {
        if(instace != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instace = this;
            DontDestroyOnLoad(gameObject);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        ShowLoadingScreen();
    }

    public void LoadLevel(string LevelName)
    {
        Loading_Bar_Holder.SetActive(true);
        progress_Value = 0f;

        //Time.timeScale = 0f;
        SceneManager.LoadScene(LevelName);
    }

    void ShowLoadingScreen()
    {
        if (progress_Value < 1f)
        {
            progress_Value += progress_Multiple_1 * progress_Multiple_2;
            Loading_Bar_Progress.fillAmount = progress_Value;
            //the loading bar has finished
            if(progress_Value >= 1f)
            {
                progress_Value = 1.1f;

                Loading_Bar_Progress.fillAmount = 0f;
                Loading_Bar_Holder.SetActive(false);

                //Time.timeScale=1f;
            }
        }//if progress value < 1
    }
    
    IEnumerator LoadingSomeLevel()
    {
        yield return new WaitForSeconds(Load_Level_Time);
        LoadLevel("MainMenu");
        //LoadLevelasync("MianMenu");
    }

    public void LoadLevelasync(string LevelName)
    {
        StartCoroutine(LoadAsynchronously(LevelName));
    }

    IEnumerator LoadAsynchronously(string LevelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevelName);
        Loading_Bar_Holder.SetActive(true);

        //while the operation is NOT DONE
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            Loading_Bar_Progress.fillAmount = progress;

            if (progress >= 1f)
            {
                Loading_Bar_Holder.SetActive(false);
            }
            yield return null;
        }
    }
}