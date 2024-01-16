using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed = 12.0f;
    
    [SerializeField] private GameObject _miniExplosionPrefab = default;


    private UIManager _uiManager;
    private float _vitesseFireballEnnemi;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }
    void Update()
    {
        MoveFireballPlayer();
       
    }


    /**************************************
    * Rôle: Gestion du mouvement de la fireball
    **************************************/
    private void MoveFireballPlayer()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _speed);
        if (transform.position.x > 11f)
        {
            if (transform.parent == null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
    }

    /******************************************************
    * Rôle: Gestion du contact entre ennemies et fireball
    ******************************************************/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(_miniExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
