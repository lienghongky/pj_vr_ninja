using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliceable : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    ParticleSystem? bloodSplash;

    void Start()
    {
        bloodSplash = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void splash()
    {
        bloodSplash?.Play();
    }
}
