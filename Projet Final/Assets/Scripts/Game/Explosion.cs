using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip _clip = default;
    // Start is called before the first frame update
    void Start()
    {
        //Fait le bruit et d�truit l'objet
        AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 0.3f);
        Destroy(gameObject, .8f);
    }

    // Update is called once per frame
    void Update()
    {
        //D�place la boule de feu
       transform.Translate(Vector3.right * Time.deltaTime * 3.0f);
    }
}
