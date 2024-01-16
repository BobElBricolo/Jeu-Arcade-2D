using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _cadenceTir = 0.5f;
    [SerializeField] private InputActionAsset _actionAsset = default;
    [SerializeField] private GameObject _fireballPrefab = default;
    [SerializeField] private GameObject _arrow = default;
    [SerializeField] private GameObject _explosionPrefab = default;
    [SerializeField] private GameObject _shield = default;
    [SerializeField] private int _viesJoueur = 10;
    [SerializeField] private int _CastleLife = 10;

    public HealthBar healthBar;
    public bool estVivant = true;

    private Vector3 _direction;
    private Rigidbody2D _rb;
    private float _canFire = -1.0f;
    private UIManager _uiManager;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction AttackAction;
    private float vitesseInitiale;
    private Animator _anim;
    private bool attaque = false;
    private bool deplacement = false;
    private GameObject _epee;
    

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _epee = transform.GetChild(1).gameObject;
        healthBar.setMaxHealth(_viesJoueur);
        

        if (this.transform != null)
        {
            transform.position = new Vector3(0f, 0f, 0f); // D�place le joueur � sa position initiale
            _rb = this.GetComponent<Rigidbody2D>();  // r�cup�re le rigidbody du joueur
            _anim = GetComponent<Animator>();

            //Active et d�sactive le d�placement du joueur avec l'action Move
            moveAction = _actionAsset.FindAction("Move");
            moveAction.performed += MoveAction_performed;
            moveAction.canceled += MoveAction_canceled;
            moveAction.Enable();


            //Active l'action pour tirer des lasers
            fireAction = _actionAsset.FindAction("Fire");
            fireAction.performed += FireAction_performed;
            fireAction.Enable();

            //Active l'action pour tirer des lasers
            AttackAction = _actionAsset.FindAction("Attack");
            AttackAction.performed += AttackAction_performed;
            AttackAction.canceled += AttackAction_canceled;
            AttackAction.Enable();
        }
    }

        // Update is called once per frame
        void Update()
    {
        LimiterMouvement();
        GestionAnims();
    }
    /*********************************************
    * R�le: Gestion des d�placements des joueurs
    *********************************************/
    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        if (attaque == false)
        {
            Vector2 direction2D = obj.ReadValue<Vector2>();
            _direction = new Vector3(direction2D.x, direction2D.y, 0f);
            _direction.Normalize();
            _rb.velocity = (_direction * _speed);
            deplacement = true;
        }
    }

     /* Entr�e : l'�l�ment qui a cesser l'action avec ses valeurs
     * Sortie : rien
     * R�le : Actions � effectuer � l'annulation de l'action Move
     */
     private void MoveAction_canceled(InputAction.CallbackContext obj)
     {
         _direction = new Vector3(0f, 0f, 0f); //remet le d�placement � 0
         _rb.velocity = (_direction * _speed);
         deplacement = false;
     }


    /**************************************
    * R�le: Bordure du jeu
    **************************************/
    private void LimiterMouvement()
        {

            //limite le mouvement vertical
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -2.8f, 3.5f), 0f);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.0f, 9.0f), transform.position.y, 0f);
    }

    /**************************************
    * R�le: Gestion des animations
    **************************************/
    private void GestionAnims()
    {
        
       
        if (_direction.x > 0 || _direction.x < 0f || _direction.y > 0 || _direction.y < 0)
        { 
            _anim.SetBool("Run", true);
        }

        else if (_direction.x == 0)
        {
            _anim.SetBool("Run", false);
        }

        if (_viesJoueur < 1)
        {
            _anim.SetBool("Death", true);
        }
        else
        {
            _anim.SetBool("Death", false);
        }

    }

    /**************************************
    * R�le: Gestion du tir de boule de feu
    **************************************/
    private void FireAction_performed(InputAction.CallbackContext obj)
        {
            if (Time.time > _canFire)
            {
                Instantiate(_fireballPrefab, transform.position + new Vector3(0f, -1f, 0f), Quaternion.identity);
                //GetComponent<AudioSource>().Play();
                _canFire = Time.time + _cadenceTir;
            }
        }

    /**************************************
    * R�le: Gestions des attacks de m�l�e
    **************************************/
    private void AttackAction_performed(InputAction.CallbackContext obj)
    {
        if (deplacement == false)
        {
            _anim.SetBool("Attack", true);
            attaque = true;
            _epee.SetActive(true);
        }
    }

    /**************************************
    * R�le: cancel des attacks
    **************************************/
    private void AttackAction_canceled(InputAction.CallbackContext obj)
    {
        _anim.SetBool("Attack", false);
        attaque = false;
        _epee.SetActive(false);
    }

    /**************************************
    * R�le: Gestion de la perte de vie
    * et de la mort du joueur
    **************************************/
    public void Dommage()
    {
        if (!_shield.activeSelf)
        {
            _viesJoueur -= 1;
           healthBar.SetHealth(_viesJoueur);
        }
        else
        {
            _shield.SetActive(false);
        }
        
        if (_viesJoueur < 1)
        {
            StartCoroutine(MortAttente());
            estVivant = false;
            FindObjectOfType<SpawnManager>().finJeu();
            _uiManager.GameOverSequence();
            FindObjectOfType<UIManager>().GameOverSequence();


        }
    }

    /**************************************
    * R�le: Gestion des power up
    **************************************/
    public void SpeedPowerUp()
    {
        vitesseInitiale = _speed;
        _speed = 7.0f;
        StartCoroutine(ArretSpeedPowerUp());
    }

    public void ArrowPowerUp() //Power up explosion
    {
        _arrow.SetActive(true);
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        StartCoroutine(ArretArrowPowerUp());
    }

    public void ShieldPowerUp()
    {
        _shield.SetActive(true);
    }

    /**************************************
    * R�le: routine pour arr�ter les effets
    * des power up
    **************************************/
    IEnumerator ArretSpeedPowerUp()
    {
        yield return new WaitForSeconds(5.0f);
        _speed = vitesseInitiale;
    }

    IEnumerator ArretArrowPowerUp()
    {
        yield return new WaitForSeconds(2.0f);
        _arrow.SetActive(false);
    }

    IEnumerator MortAttente()
    {
        _anim.SetBool("Death", true);
        yield return new WaitForSeconds(1f);
        ArretCallBackPlayer();
        Destroy(this.gameObject);
        _uiManager.GameOverSequence();
    }

    /**************************************
    * R�le: Cancel des actions
    **************************************/
    public void ArretCallBackPlayer()
    {
        moveAction.performed -= MoveAction_performed;
        moveAction.canceled -= MoveAction_canceled;
        fireAction.performed -= FireAction_performed;
    }

}
