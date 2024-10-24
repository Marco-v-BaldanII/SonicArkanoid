using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esmerald : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
