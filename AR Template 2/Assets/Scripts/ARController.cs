using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject spawnObject;

    bool isSpawn = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetPose();
    }

    void SetPose()
    {


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.GetTouch(0).position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

            if (hits.Count > 0)
            {
                if (isSpawn)
                {
                    Instantiate(spawnObject, hits[0].pose.position, Quaternion.Euler(new Vector3(0, 135, 0)));
                }
                isSpawn = false;
            }
        }
    }
}
