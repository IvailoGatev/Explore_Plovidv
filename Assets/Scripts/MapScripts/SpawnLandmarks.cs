using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLandmarks : MonoBehaviour
{
    private static LandmarkInformation script;
    private static int count;
    private static bool isInisialized;

    private int id;

    void Start()
    {
        if(!isInisialized)
        {
            count = 1;
            script = this.GetComponent<LandmarkInformation>();
            isInisialized = true;
        }
        id = count-1;
        count++;
        this.gameObject.name=script.GetLandmarkName(id);
        GameObject landmarksObject = GameObject.Find("Landmarks");
        this.transform.parent = landmarksObject.transform;
    }

    public void OnSphereClick()
    {
        SceneManager.LoadSceneAsync("Landmark0Scene");
    }
}
