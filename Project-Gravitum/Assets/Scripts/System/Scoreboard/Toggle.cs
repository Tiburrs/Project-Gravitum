﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas visible;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggle()
    {
        visible.enabled = !visible.enabled;
    }
}