using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpectrometer : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    private GameObject[] cubes;
    [SerializeField] private int count = 512;
    [SerializeField] private float dalnost = 100f;
    [SerializeField] private float maxScale = 1000;
    void Start()
    {
        cubes = new GameObject[count];

        for(int i = 0; i < count; i++)
        {
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.position = this.transform.position;
            cube.transform.parent = this.transform;
            cube.name = "Cube" + i;
            this.transform.eulerAngles = new Vector3(0, -360.0f/count * i, 0);
            cube.transform.position = Vector3.forward * dalnost;
            cubes[i] = cube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < count; i++)
        {
            if (cubes != null)
                cubes[i].transform.localScale = new Vector3(10, (AudioSpectrometer.samples[i] * maxScale) + 2, 10);
        }
    }
}
