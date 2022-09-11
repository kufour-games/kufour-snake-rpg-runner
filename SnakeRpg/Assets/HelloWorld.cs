using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Start!");
    }

    private void Awake()
    {
        Debug.Log("Hello Awake!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
