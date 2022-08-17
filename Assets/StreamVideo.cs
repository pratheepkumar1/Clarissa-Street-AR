using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;


public class StreamVideo : MonoBehaviour
{

    public RawImage rawImage;
    public VideoPlayer videoSource;
    public AudioSource audioSource;
    public GameObject videoControls;

    public double time;
    public double currentTime;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        videoControls.SetActive(false);
        StartCoroutine(PlayVideo());
        time = videoSource.GetComponent<VideoPlayer>().clip.length;

    }

    IEnumerator PlayVideo()
    {
        videoSource.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(!videoSource.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }

        rawImage.texture = videoSource.texture;
        videoSource.Play();
        audioSource.Play();
    }


    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
                videoControls.SetActive(true);
        }
        else
        {

        }

        currentTime = gameObject.GetComponent<VideoPlayer>().time;
        if (currentTime >= time)
        {
            LoadScene("Home Screen");
        }
    }

    public void LoadScene(string sceneName)
    {
        videoSource.Stop();
        audioSource.Stop();
        SceneManager.LoadScene(sceneName);
        StopAllCoroutines();
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
