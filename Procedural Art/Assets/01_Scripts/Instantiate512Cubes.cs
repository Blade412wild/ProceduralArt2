using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour
{
    public audioCollector collector; 
    public GameObject CubeSamplePrefab;
    private GameObject[] sampleCube = new GameObject[512];

    public float maxScale;
    private int counter = 0;
    private int bandID = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            if(counter == 64)
            {
                bandID++;
                counter = 0;
            }
            GameObject instanceSampleCube = (GameObject)Instantiate(CubeSamplePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "Cube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;
            sampleCube[i] = instanceSampleCube;
            instanceSampleCube.GetComponent<CircleCubes>().band = bandID;
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (sampleCube != null)
            {
                //Debug.Log(collector);
                //sampleCube[i].transform.localScale = new Vector3(10, collector.samples[i] * maxScale, 1);
            }
        }
    }
}
