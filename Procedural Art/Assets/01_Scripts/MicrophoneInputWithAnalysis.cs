using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInputWithAnalysis : MonoBehaviour
{
    private AudioSource audioSource;
    public float updateStep = 0.1f;
    private float currentUpdateTime = 0f;

    public int sampleDataLength = 1024;

    private float[] clipSampleData;
    private float[] spectrumData;

    string microphoneName;
    public float decibel;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        clipSampleData = new float[sampleDataLength];
        spectrumData = new float[sampleDataLength];
    }

    void Start()
    {
        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("Microphone not found");
            return;
        }
        int counter = 0;
        foreach (var device in Microphone.devices)
        {
            if (counter == 1)
            {
                microphoneName = device;
            }
            Debug.Log("Name: " + device);
            counter++;
        }
        audioSource.clip = Microphone.Start(microphoneName, true, 10, 44100);
        while (!(Microphone.GetPosition(microphoneName) > 0)) { }
        audioSource.Play();
    }

    void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, Microphone.GetPosition(microphoneName) - sampleDataLength);
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
            float levelMax = 0;
            for (int i = 0; i < clipSampleData.Length; i++)
            {
                float wavePeak = clipSampleData[i] * clipSampleData[i];
                if (levelMax < wavePeak)
                {
                    levelMax = wavePeak;
                }
            }
            decibel = 20 * Mathf.Log10(Mathf.Sqrt(levelMax));
            

            float pitch = CalculatePitch(spectrumData);

            //Debug.Log($"Decibel: {decibel}, Pitch: {pitch} Hz");
        }
    }

    float CalculatePitch(float[] spectrum)
    {
        float maxV = 0;
        var maxN = 0;
        for (int i = 0; i < spectrum.Length; i++)
        {
            if (!(spectrum[i] > maxV) || !(spectrum[i] > 0.0f))
                continue;

            maxV = spectrum[i];
            maxN = i;
        }
        float freqN = maxN;
        if (maxN > 0 && maxN < spectrum.Length - 1)
        {
            var dL = spectrum[maxN - 1] / spectrum[maxN];
            var dR = spectrum[maxN + 1] / spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        float pitch = freqN * (AudioSettings.outputSampleRate / 2) / spectrum.Length;
        return pitch;
    }

    void OnDisable()
    {
        Microphone.End(null);
    }
}
