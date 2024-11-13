using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrometer : MonoBehaviour
{
    private AudioSource audioSource;
    public static float[] samples = new float[512];
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData( samples, 0, FFTWindow.Blackman);
    }
}
