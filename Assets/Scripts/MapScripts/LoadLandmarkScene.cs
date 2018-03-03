using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLandmarkScene : MonoBehaviour
{
	void OnMouseDown()
    {
        this.gameObject.transform.parent.GetComponentInParent<SpawnLandmarks>().OnSphereClick();
    }
}
