using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    [SerializeField] private float _vitesseEnnemis = 5.0f;
    [SerializeField] private float _attackSpeed = 2.0f;
    [SerializeField] private float _ennemiesLimite = -10.0f;
    [SerializeField] private int _ennemiesId = 0;
    [SerializeField] private float _enemyHP = 1.0f;
    [SerializeField] private GameObject _hit = default;

    private bool _isWalking = true;
    private bool _isAlive = true;
    private float _canAttack = 0.0f;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MouvementEnemy();
        GestionAnims();
        AttackEnemy();
        GestionMort();
    }

    /*
     * But : Gestion des animations
     */
    private void GestionAnims()
    {
        if(_isWalking ==true) // marcher
        {
 
            _anim.SetBool("walking", true);
        }
        else if (_isWalking == false && _isAlive == true) // attaquer
        {
            _anim.SetBool("walking", false);         
        }

        if(_isAlive == false) //mourir
        {
            _anim.SetBool("alive", false);
        }
    }

    /*
     * But : faire avancer les ennemies
     */
    private void MouvementEnemy()
    {
        if (_isWalking == true)
        { 

            transform.Translate(Vector3.left * Time.deltaTime * _vitesseEnnemis);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _ennemiesLimite, 100.0f), transform.position.y, 0f);
            if (transform.position.x == _ennemiesLimite)
            {
                _isWalking = false;
                _canAttack = Time.time + _attackSpeed; //attack enemy limite: attente avant d'attaquer pour golem
            }

        }
        else 
        {

        }
    }

    /*
     * But : faire mourir les ennemies
     */
    private void GestionMort()
    {
        if(_enemyHP <= 0)
        {
            _isWalking = false; //arrêter d'avancer
            _isAlive = false; // mort du sujet
            StartCoroutine(DeathWaiting());
            
        }
    }

    /*
     * But: gérer l'attaque des ennemies
     * 0:skelette
     * 1:golem
     * 2:demon
     */
    private void AttackEnemy()
    {
        if (_isWalking == false && Time.time >= _canAttack && _isAlive == true)
        {
            switch (_ennemiesId)
            {
                case 0:
                Instantiate(_hit, transform.position + new Vector3(-1.0f, 0f, 0f), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_hit, transform.position + new Vector3(-1.0f, 0.4f, 0f), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_hit, transform.position + new Vector3(-2.0f, 0f, 0f), Quaternion.identity);
                    break;

            }
            _canAttack += _attackSpeed; // attente avant le prochain coup

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Castle")
        {
            _isWalking = false;
            _canAttack = Time.time +_attackSpeed; //attack enemy collision
                    
        }    
        else if (other.tag == "Attack" || other.tag == "Fireball")
        {
            _enemyHP = 0;
            FindObjectOfType<UIManager>().AjouterScore(5);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Castle")
        {
            _isWalking = true;

        }
       
    }/*
      * 
      * fonction perdre de la vie 
      * qui devrait se faire call dans le
      * coup du héro 
      */
    IEnumerator DeathWaiting()
    {
        yield return new WaitForSeconds(1.0f);
        //Ajouter le score ****************************************************************************
        Destroy(gameObject);


    }


}
