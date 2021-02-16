using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currsor : MonoBehaviour
{
    CursorLockMode wantedMode;

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = wantedMode = CursorLockMode.None;

        GUILayout.EndVertical();

        SetCursorState();
    }
    void Start()
    {
        wantedMode = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            wantedMode = CursorLockMode.Locked;
        }
    }
}

