using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMusiqueDepart : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = FindObjectOfType<MusiqueFond>().GetComponent<AudioSource>();
    }

    public void MusiqueOnOff()
    {

        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            _audioSource.volume = 0.078f;
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            _audioSource.volume = 0;
        }
    }
}
