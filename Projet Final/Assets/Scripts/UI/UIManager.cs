using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour  {

    [SerializeField] private InputActionAsset _actionsAsset = default;
    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private TextMeshProUGUI _txtGameOver = default;
    [SerializeField] private TextMeshProUGUI _txtRestart = default;
    [SerializeField] private TextMeshProUGUI _txtQuit = default;
    [SerializeField] private GameObject _pausePanel = default;
    [SerializeField] private GameObject _GameOver = default;
    

    private int _score;
    private bool _estChanger;
    private AudioSource _musique;
    private bool _pauseOn = false;
    private InputAction pause;
    private InputAction restart;
    private Player _player;
    
    // Start is called before the first frame update

    private void Start() {
        _player = FindObjectOfType<Player>();
        _musique = FindObjectOfType<MusiqueFond>().GetComponent<AudioSource>();
        _score = 0;
        _estChanger = false;
        _pauseOn = false;
        Time.timeScale = 1;
        UpdateScore();

        restart = _actionsAsset.FindActionMap("UI").FindAction("Restart");
        restart.performed += Restart_performed;
        restart.Enable();

        pause = _actionsAsset.FindActionMap("UI").FindAction("Pause");
        pause.performed += Pause_performed;
        pause.Enable();


    }

    /**************************************
    * Rôle: Arret avec la touche esc
    **************************************/
    private void Pause_performed(InputAction.CallbackContext obj)
    {
            if(_pauseOn)
            {
                _pausePanel.SetActive(false);
                Time.timeScale = 1;
                _pauseOn = false;
            }
            else
            {
                _pausePanel.SetActive(true);
                Time.timeScale = 0;
                _pauseOn = true;
            }
    }

    /**************************************
    * Rôle: Relancer avec la touche esc
    **************************************/
    private void Restart_performed(InputAction.CallbackContext obj)
    {
        if(_txtRestart.gameObject.activeSelf)
        {
            ArretCallBackUI();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   
    public void AjouterScore(int points) {
        _score += points;
        UpdateScore();
    }

    private void UpdateScore() {
        _txtScore.text = _score.ToString();
    }


    public void GameOverSequence() {
       _GameOver.SetActive(true);
        Time.timeScale = 0;
    }

    /**************************************
    * Rôle: Relancer avec le bouton
    **************************************/
    public void ResumeGame() {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }

    /**************************************
    * Rôle: Retour au début
    **************************************/
    public void RetourDebut()
    {
        ArretCallBackUI();
        _player.ArretCallBackPlayer();
        SceneManager.LoadScene(0);
       
    }

    public void ArretCallBackUI()
    {
        pause.performed -= Pause_performed;
        restart.performed -= Restart_performed;
    }

    public void MusiqueOnOff()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            _musique.volume = 0.078f;
            
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            _musique.volume = 0f;

        }
    }


    public int getScore()
    {
        return _score;
    }

    public bool getEstChanger()
    {
        return _estChanger;
    }

    public void setEstChanger(bool valeur)
    {
        _estChanger = valeur;
    }
}
