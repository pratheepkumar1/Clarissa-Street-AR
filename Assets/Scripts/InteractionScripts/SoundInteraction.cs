using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundInteraction : MonoBehaviour
{
    public AudioClip[] aClips;
    public AudioSource audioSource;
    public GameObject musicalNotes;
    string btnTxt;
    string autoInteractTxt;

    [SerializeField]
    private Camera arCamera;

    private GameObject musicAnimation;


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
                if (btnTxt == "Sound Interaction" && !audioSource.isPlaying)
                {
                    audioSource.clip = aClips[0];
                    audioSource.Play();
                    musicAnimation = Instantiate(musicalNotes, hit.transform.position, Quaternion.identity, hit.transform);
                    //isPlaying = true;
                }
                else if(btnTxt == "Sound Interaction" && audioSource.isPlaying)
                {
                    audioSource.Stop();
                    Destroy(musicAnimation);
                }
          
            }
        }

        if(musicAnimation != null)
        {
            if (!audioSource.isPlaying)
            {
                Destroy(musicAnimation);
            }
        }

        //Transform GetClosestEnemy(Transform[] enemies)
        //{
        //    Transform bestTarget = null;
        //    float closestDistanceSqr = Mathf.Infinity;
        //    Vector3 currentPosition = transform.position;
        //    foreach (Transform potentialTarget in enemies)
        //    {
        //        Vector3 directionToTarget = potentialTarget.position - currentPosition;
        //        float dSqrToTarget = directionToTarget.sqrMagnitude;
        //        if (dSqrToTarget < closestDistanceSqr)
        //        {
        //            closestDistanceSqr = dSqrToTarget;
        //            bestTarget = potentialTarget;
        //        }
        //    }
        //    return bestTarget;
        //}


        //RaycastHit objHit;
        //if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out objHit, Mathf.Infinity))
        //Debug.Log(objHit.transform.parent.transform);


        //Non touch based sound interaction using Camera Raycast
        //RaycastHit cameraHit;

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