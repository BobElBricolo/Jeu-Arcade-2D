using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiqueFond : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        int nbMusiqueFond = FindObjectsOfType<MusiqueFond>().Length;
        if(nbMusiqueFond > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
