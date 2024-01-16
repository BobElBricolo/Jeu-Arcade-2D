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
    //[SerializeField] private float _vitesseEnnemi = 6.0f;
    //[SerializeField] private float _augVitesseParNiveau = 2.0f;

    private int _score;
    private bool _estChanger;

    private bool _pauseOn = false;
    private InputAction pause;
    private InputAction restart;
    private Player _player;
   // private AudioSource _musique;
    
    // Start is called before the first frame update

    private void Start() {
        _player = FindObjectOfType<Player>();
        //_musique = FindObjectOfType<MusiqueFond>().GetComponent<AudioSource>();
        _score = 0;
        _estChanger = false;
        _pauseOn = false;
        Time.timeScale = 1;
        //_txtGameOver.gameObject.SetActive(false);
        //UpdateScore();

        restart = _actionsAsset.FindActionMap("UI").FindAction("Restart");
        restart.performed += Restart_performed;
        restart.Enable();

        pause = _actionsAsset.FindActionMap("UI").FindAction("Pause");
        pause.performed += Pause_performed;
        pause.Enable();


    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {
        if (_txtRestart.gameObject.activeSelf)
        {
            ArretCallBackUI();
            _player.ArretCallBackPlayer();
            SceneManager.LoadScene(0);
        }
        else
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
    }

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
        _txtScore.text = "Score : " + _score.ToString();
    }


    public void GameOverSequence() {
        _GameOver.SetActive(true);
        //_txtGameOver.gameObject.SetActive(true);
        //_txtRestart.gameObject.SetActive(true);
        //_txtQuit.gameObject.SetActive(true);
        //StartCoroutine(GameOverBlinkRoutine());
    }

   /* IEnumerator GameOverBlinkRoutine() {
        while (true) {
            _txtGameOver.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            _txtGameOver.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }
    }*/

    public void ResumeGame() {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }

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

    /*public void MusiqueOnOff()
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
    }*/

    /*public void AugmentVitesseEnnemi()
    {
        _vitesseEnnemi += _augVitesseParNiveau;
    }

    public float getVitesseEnnemi()
    {
        return _vitesseEnnemi;
    }*/

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
