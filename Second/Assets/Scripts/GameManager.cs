using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private void Start()
    {
        FindObjectOfType<DataManager>().LoadDataFromJson();    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // Eventually Change this to event driven
        {
            FindObjectOfType<DataManager>().SaveIntoJson();
        }
    }
}
