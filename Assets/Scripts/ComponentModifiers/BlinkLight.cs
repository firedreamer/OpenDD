using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour 
{
    Light lightSource;
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    float random;
 
     void Start()
     {
         lightSource = GetComponent<Light>();
         random = Random.Range(0.0f, 65535.0f);
     }
 
     void Update()
     {
         float noise = Mathf.PerlinNoise(random, Time.time);
         lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
     }
}
