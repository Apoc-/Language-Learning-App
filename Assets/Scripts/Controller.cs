﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller: MonoBehaviour
{
    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
