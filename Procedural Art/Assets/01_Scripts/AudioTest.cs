using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    [Header("yes")]
    [SerializeField] private MicrophoneInputWithAnalysis microfoon;
    [SerializeField] private Transform bal;



    [Header("settings")]
    [SerializeField] private float minThreshold;
    [SerializeField] private float maxThreshold;

    [Header("output")]
    [Range(-90.0f, 0.0f)]
    [SerializeField] private float input;

    [Range(-1000f, 1000f)]
    [SerializeField] private float firstOutput = 0;

    [Range(-1000f, 1000f)]
    [SerializeField] private float secondOutput = 0;
    [SerializeField] private float thirdOutput = 0;

    private cubeTest cubeTest;



    // Start is called before the first frame update
    void Start()
    {
        cubeTest = bal.GetComponent<cubeTest>();
    }

    // Update is called once per frame
    void Update()
    {

        input = microfoon.decibel;

        if (input > minThreshold)
        {
            firstOutput = Map.MapFunction2(input, minThreshold, maxThreshold, 1, 2);
            //firstOutput = input;

        }

    }
}
