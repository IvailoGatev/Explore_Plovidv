using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{

	public void LoadMap()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void LoadCamera()
    {
        SceneManager.LoadSceneAsync("CameraScene");
    }

}
