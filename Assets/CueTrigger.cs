using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueTrigger : MonoBehaviour
{

    public Camera arCamera;

    string btnTxt;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TriggerCue(arCamera);
    }

    //public void TestDebug()
    //{
    //    audioSource = this.gameObject.GetComponent<AudioSource>();
    //    audioSource.clip = aClips[0];
    //    audioSource.Play();
    //    Debug.Log(aClips[0].name);
    //    Debug.Log("Cue Trigger script readable");
    //}

    public void TriggerCue(Camera arCam)
    {

        arCamera = arCam;

        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit, Mathf.Infinity))
        {
            btnTxt = hit.transform.tag;
            Debug.Log(btnTxt);
            if(btnTxt == "Cue")
            {
                hit.transform.Find("Cue").gameObject.SetActive(true);
            }

        }
        else
        {

        }
    }
}
