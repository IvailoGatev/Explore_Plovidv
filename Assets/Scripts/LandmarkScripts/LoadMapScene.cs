using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMapScene : MonoBehaviour {

	public void LoadMap()
    {
        SceneManager.LoadScene("MapScene");
    }
}
