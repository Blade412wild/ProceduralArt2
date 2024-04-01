using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class audioCollector : MonoBehaviour
{
    private AudioSource audioSource;
    public float[] samples = new float[512];
    public float[] freqband = new float[8];
    public float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];

    private float[] freqBandHighest = new float[8];
    public float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudiobands();
    }

    void CreateAudiobands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqband[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqband[i];
                if (i == 0)
                {
                }
            }
            if(i == 0 && freqband[i] > 4)
            {
                Debug.Log("bam");
            }
            audioBand[i] = (freqband[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);

        }
    }

    private void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    private void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqband[i] > bandBuffer[i])
            {
                bandBuffer[i] = freqband[i];
                bufferDecrease[i] = 0.005f;
            }

            if (freqband[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }

    private void MakeFrequencyBands()
    {
        /*
         * 22050 / 512 = 43 hertz per sample
         * 
         * 20 - 60 hertz
         * 60 - 250 hertz
         * 250 - 500 hertz
         * 500 - 2000 hertz
         * 2000 - 4000 hertz
         * 4000 - 6000 hertz
         * 6000 - 20000 hertz
         * 
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;

            }

            average /= sampleCount;
            freqband[i] = average * 10;
        }

    }
}
