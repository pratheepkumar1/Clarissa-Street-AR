using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    [SerializeField]
    private GameObject arCameras;

    [SerializeField]
    private GameObject mediaObject;

    internal float dist;
    public float range = 2;


    //public Material opaqueMat;
    //public Material transparentMat;
    public Material[] materials;
    Material[] currentlyAssignedMaterials;


    [SerializeField]
    private Camera arCamera;


    string objTag;



    // Start is called before the first frame update
    public void Start()
    {
        Debug.Log(GameObject.Find("Selector").transform.position);

        if (arCamera == null)
        {
            arCameras = GameObject.Find("AR Camera");
        }

        currentlyAssignedMaterials = GetComponent<Renderer>().materials;



        //this.materialsArray = this.GetComponent<Renderer>().materials;
        //foreach (Material material in materialsArray)
        //{
        //    Debug.Log(material.name);
        //    Debug.Log(material.color);


        //    if (material.name == "M_265ClarissaGlas_Sh (Instance)")
        //    {
        //        material.color = new Color(0.2924528f, 0.2717604f, 0.2717604f, 0f);
        //        Debug.Log("Color Change");
        //        Debug.Log(material.name);
        //        Debug.Log(material.color);
        //    }
        //}
    }


    //public void FixedUpdate()
    //{
    //    if (arCamera != null)
    //    {
    //        dist = Vector3.Distance(transform.position, arCamera.transform.position);
    //        if (dist < 4)
    //        {
    //            mediaObject.SetActive(true);
    //            //Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color);
    //        }
    //        else
    //        {
    //            mediaObject.SetActive(false);
    //        }
    //    }


    //}

    private void Update()
    {

        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    // Get a ray from the camera to the point where the user has touches on the screen (so the parameter is user touch position)
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;

        //    //Check if touch has hit an object
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        objTag = hit.transform.tag;
        //        if (objTag == "Window Image" && currentlyAssignedMaterials[1] != materials[2])
        //        {
        //            currentlyAssignedMaterials[1] = materials[2];
        //            GetComponent<Renderer>().materials = currentlyAssignedMaterials;
        //            mediaObject.SetActive(true);

        //        }
        //        else
        //        {
        //            currentlyAssignedMaterials[1] = materials[1];
        //            GetComponent<Renderer>().materials = currentlyAssignedMaterials;
        //            mediaObject.SetActive(false);

        //        }


        //    }
        //}



        //Ray ray = arCamera.ScreenPointToRay(GameObject.FindGameObjectWithTag("Window Image").transform.position);

        //RaycastHit objHit;

        //if (Physics.Raycast(ray, out objHit, 100f))
        //{
        //    Debug.Log("ray passed");
        //    //    Debug.Log(objHit.transform.name);
        //}
        //else
        //{
        //    Debug.Log("Didn't hit");
        //}



        //if (Physics.Raycast(arCameras.transform.position, arCameras.transform.forward, out objHit, Mathf.Infinity))
        //{
        //    Debug.Log("ray passed");
        //    Debug.Log(objHit.transform.name);
        //}
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.green;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, range);
        UnityEditor.Handles.Label(transform.position, gameObject.name + "\nRange = " + range);
    }

#endif
}
