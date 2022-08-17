using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class MediaManager : MonoBehaviour
{

    public RawImage rawImage;
    public VideoPlayer[] videoSource;
    public AudioSource[] audioSource;
    public GameObject canvas;
    public GameObject videoControls;

    private VideoPlayer currentVideoSource;
    private AudioSource currentAudioSource;

    [SerializeField]
    private Camera arCamera;

    string objTag;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            // Get a ray from the camera to the point where the user has touches on the screen (so the parameter is user touch position)
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            //Check if touch has hit an object
            if (Physics.Raycast(ray, out hit))
            {
                objTag = hit.transform.tag;
                if(objTag == "Video")
                {
                    canvas.SetActive(true);
                    switch (hit.transform.parent.name)
                    {
                        case "South Window":
                            currentVideoSource = videoSource[0];
                            currentAudioSource = audioSource[0];
                            rawImage.GetComponent<AspectRatioFitter>().aspectRatio = 1.77f;
                            StartCoroutine(PlayVideo(currentVideoSource, currentAudioSource));
                            break;
                        case "Stage Window":
                            currentVideoSource = videoSource[1];
                            currentAudioSource = audioSource[1];
                            rawImage.GetComponent<AspectRatioFitter>().aspectRatio = 0.56f;
                            StartCoroutine(PlayVideo(currentVideoSource, currentAudioSource));
                            break;
                        case "Piano Window":
                            currentVideoSource = videoSource[2];
                            currentAudioSource = audioSource[2];
                            rawImage.GetComponent<AspectRatioFitter>().aspectRatio = 1.77f;
                            StartCoroutine(PlayVideo(currentVideoSource, currentAudioSource));
                            break;
                        default:
                            Debug.Log("No Object with Video Name");
                            break;

                    }

                }


            }
        }
    }

    IEnumerator PlayVideo(VideoPlayer currentVideo,AudioSource currentAudio)
    {
        currentVideo.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(2);
        while (!currentVideo.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = currentVideo.texture;
        currentVideo.Play();
        currentAudio.Play();
    }


    public void DismissOverlay()
    {
        currentVideoSource.Stop();
        currentVideoSource.Stop();
        canvas.SetActive(false);
        rawImage.texture = null;
        StopAllCoroutines();
    }
}
