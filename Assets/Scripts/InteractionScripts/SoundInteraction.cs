using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundInteraction : MonoBehaviour
{
    public AudioClip[] aClips;
    public AudioSource audioSource;
    string btnTxt;

    [SerializeField]
    private Camera arCamera;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //Touch based sound interaction
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            // Get a ray from the camera to the point where the user has touches on the screen (so the parameter is user touch position)
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            //Check if touch has hit an object
            if (Physics.Raycast(ray, out hit))
            {
                btnTxt = hit.transform.tag;
                if (btnTxt == "Sound Interaction")
                {
                    audioSource.clip = aClips[0];
                    audioSource.Play();
                }
            }
        }


        //Non touch based sound interaction using Camera Raycast
        //RaycastHit hit;

        //if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit, 50.0f))
        //{
        //    btnTxt = hit.transform.tag;
        //    if (btnTxt == "Sound Interaction")
        //    {
        //        audioSource.clip = aClips[0];
        //        audioSource.Play();
        //    }

        //}


        //Non touch based sound interaction usign Frustrum Planes
        //    foreach (Transform child in transform)
        //{

        //    if (child.tag == "Sound Interaction" && IsVisbile(arCamera, child))
        //    {
        //        Destroy(child.gameObject);
        //        //audioSource.clip = aClips[0];
        //        //audioSource.Play();
        //    }
        //}
    }
    }