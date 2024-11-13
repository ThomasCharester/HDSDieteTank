using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSpectrometer : MonoBehaviour
{
    private ParticleSystem spectrometerSystem;
    [SerializeField] private int selectedRate = 0;
    void Start()
    {
        spectrometerSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        spectrometerSystem.Emit((int)(AudioSpectrometer.samples[selectedRate] * 100));
    }
}
