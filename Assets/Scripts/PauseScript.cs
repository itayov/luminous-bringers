﻿using System.Collections;
using System.Collections.Generic;
using QuantumTek.MenuSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QuantumTek.MenuSystem.Menu.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!QuantumTek.MenuSystem.Menu.isPaused)
            {
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);

                while (!asyncOperation.isDone)
                {
                    if (asyncOperation.progress >= 0.9f)
                    {
                        QuantumTek.MenuSystem.Menu.isPaused = true;

                        //Activate the Scene
                        asyncOperation.allowSceneActivation = true;

                        return;
                    }
                }
            }
            else
            {
                QuantumTek.MenuSystem.Menu.isPaused = false;
                SceneManager.UnloadScene("PauseScene");
            }
        }

        if (QuantumTek.MenuSystem.Menu.isPaused)
        {
            // TODO Add disable for enemies and more
            PlayerController.isInputEnabled = false;
        }
        else
        {
            // TODO Add enable for enemies and more
            PlayerController.isInputEnabled = true;
        }
    }
}
