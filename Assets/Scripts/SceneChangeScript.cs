using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    // Start is called before the first frame updat
    public void ChangeScene(String Name)
    {
        SceneManager.LoadScene(Name);
    }
}
