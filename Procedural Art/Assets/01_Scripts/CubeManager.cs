using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private List<cubeTest> cubes = new List<cubeTest>();

    private int counter = 0;
    private int cubeID = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cubeID >= cubes.Count) return;
        if (counter == 100)
        {
            cubes[cubeID].move = true;
            cubeID++;
            counter = 0;
        }
        counter++;
    }

    private void TurnOnMove()
    {
        cubes[counter].move = true;
        counter++;
    }
}
