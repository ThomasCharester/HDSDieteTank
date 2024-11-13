using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterSpectrometer : MonoBehaviour
{
    public ParticleSystem spectrometerSystem;
    [SerializeField] private int selectedRate = 0;

    [SerializeField] private int particlesCountModifier = 100;

    public bool emmit = false;
    private void Awake()
    {
    }
    void Start()
    {
        spectrometerSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(emmit)
            spectrometerSystem.Emit((int)(AudioSpectrometer.samples[selectedRate] * particlesCountModifier));
    }
}
