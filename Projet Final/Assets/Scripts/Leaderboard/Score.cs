using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private TextMeshProUGUI _Hscore1 = default;
    [SerializeField] private TextMeshProUGUI _Hscore2 = default;
    [SerializeField] private TextMeshProUGUI _Hscore3 = default;
    [SerializeField] private TextMeshProUGUI _Hscore4 = default;
    [SerializeField] private TextMeshProUGUI _Hscore5 = default;

    [SerializeField] private TextMeshProUGUI _Name1 = default;
    [SerializeField] private TextMeshProUGUI _Name2 = default;
    [SerializeField] private TextMeshProUGUI _Name3 = default;
    [SerializeField] private TextMeshProUGUI _Name4 = default;
    [SerializeField] private TextMeshProUGUI _Name5 = default;
    [SerializeField] private GameObject WinnerNameTab;


    private int score;
    private int Hscore1 = 0;
    private int Hscore2 = 0;
    private int Hscore3 = 0;
    private int Hscore4 = 0;
    private int Hscore5 = 0;

    private string name1;
    private string name2;
    private string name3;
    private string name4;
    private string name5;


    private UIManager _uiManager;
    private bool once = true;

    public string theName = "Bob";
    public GameObject inputField;
    


    //PlayerPrefs.SetString

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (FindObjectOfType<Player>().estVivant == false)
        {
            score = _uiManager.getScore();
            _txtScore.text = score.ToString();

            setHighScore();
            once = false;
        }

    }

    public void SetInt(string Name, int HighScore)
    {
        PlayerPrefs.SetInt(Name, HighScore);
    }

    public int Getint(string Name)
    {
        return PlayerPrefs.GetInt(Name);
    }

    public void SetString(string Position, string Name)
    {
        PlayerPrefs.SetString(Position, Name);
    }

    
    public string GetString(string Position)
    {
        return PlayerPrefs.GetString(Position);
    }


    /**************************************
    * Rôle: Déplace les scores dans le bon numéro
    **************************************/
    private void setHighScore()
    {


        if (score > PlayerPrefs.GetInt("HighScore1"))
        {

            //WinnerNameTab.SetActive(true);

            //Position 4 devient 5
            Hscore5 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetInt("HighScore5", Hscore5);
            _Hscore5.text = Hscore5.ToString();

            name5 = PlayerPrefs.GetString("NHigscore4");
            PlayerPrefs.SetString("NHighScore5", name5);
            _Name5.text = name5;

            //Position 3 devient 4
            Hscore4 = PlayerPrefs.GetInt("HighScore3");
            PlayerPrefs.SetInt("HighScore4", Hscore4);
            _Hscore4.text = Hscore4.ToString();

            name4 = PlayerPrefs.GetString("NHigscore3");
            PlayerPrefs.SetString("NHighScore4", name4);
            _Name4.text = name4;


            //Position 2 devient 3
            Hscore3 = PlayerPrefs.GetInt("HighScore2");
            PlayerPrefs.SetInt("HighScore3", Hscore3);
            _Hscore3.text = Hscore3.ToString();

            name3 = PlayerPrefs.GetString("NHigscore2");
            PlayerPrefs.SetString("NHighScore3", name3);
            _Name3.text = name3;


            //Position 1 devient 2
            Hscore2 = PlayerPrefs.GetInt("HighScore1");
            PlayerPrefs.SetInt("HighScore2", Hscore2);
            _Hscore2.text = Hscore2.ToString();

            name2 = PlayerPrefs.GetString("NHigscore1");
            PlayerPrefs.SetString("NHighScore2", name2);
            _Name2.text = name2;

            //Changement de position 1
            Hscore1 = score;
            PlayerPrefs.SetInt("HighScore1", Hscore1);
            _Hscore1.text = score.ToString();

            name1 = theName;
            PlayerPrefs.SetString("NHighScore1", name1);
            _Name1.text = name1;
        }

        else if (score > PlayerPrefs.GetInt("HighScore2") && score <= PlayerPrefs.GetInt("HighScore1"))
        {
            //WinnerNameTab.SetActive(true);

            //Position 4 devient 5
            Hscore5 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetInt("HighScore5", Hscore5);
            _Hscore5.text = Hscore5.ToString();

            name5 = PlayerPrefs.GetString("NHigscore4");
            PlayerPrefs.SetString("NHighScore5", name5);
            _Name5.text = name5;


            //Position 3 devient 4
            Hscore4 = PlayerPrefs.GetInt("HighScore3");
            PlayerPrefs.SetInt("HighScore4", Hscore4);
            _Hscore4.text = Hscore4.ToString();

            name4 = PlayerPrefs.GetString("NHigscore3");
            PlayerPrefs.SetString("NHighScore4", name4);
            _Name4.text = name4;


            //Position 2 devient 3
            Hscore3 = PlayerPrefs.GetInt("HighScore2");
            PlayerPrefs.SetInt("HighScore3", Hscore3);
            _Hscore3.text = Hscore3.ToString();

            name3 = PlayerPrefs.GetString("NHigscore2");
            PlayerPrefs.SetString("NHighScore3", name3);
            _Name3.text = name3;


            //Changement de position 2
            Hscore2 = score;
            PlayerPrefs.SetInt("HighScore2", Hscore2);
            _Hscore2.text = score.ToString();

            name2 = theName;
            PlayerPrefs.SetString("NHighScore2", name2);
            _Name2.text = name2;



            Hscore1 = PlayerPrefs.GetInt("HighScore1");
            _Hscore1.text = Hscore1.ToString();

            name1 = PlayerPrefs.GetString("NHigscore1");
            _Name1.text = name1;

        }

        else if (score > PlayerPrefs.GetInt("HighScore3") && score <= PlayerPrefs.GetInt("HighScore2"))
        {
            //WinnerNameTab.SetActive(true);

            //Position 4 devient 5
            Hscore5 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetInt("HighScore5", Hscore5);
            _Hscore5.text = Hscore5.ToString();

            //name5 = PlayerPrefs.GetString("NHigscore4");
            //PlayerPrefs.SetString("NHighScore5", name5);
            //_Name5.text = name5;


            //Position 3 devient 4
            Hscore4 = PlayerPrefs.GetInt("HighScore3");
            PlayerPrefs.SetInt("HighScore4", Hscore4);
            _Hscore4.text = Hscore4.ToString();

            //name4 = PlayerPrefs.GetString("NHigscore3");
            //PlayerPrefs.SetString("NHighScore4", name4);
            //_Name4.text = name4;


            //Changement de position 3
            Hscore3 = score;
            PlayerPrefs.SetInt("HighScore3", Hscore3);
            _Hscore3.text = score.ToString();

            name3 = theName;
            PlayerPrefs.SetString("NHighScore3", name3);
            _Name3.text = name3;

            Hscore2 = PlayerPrefs.GetInt("HighScore2");
            _Hscore2.text = Hscore2.ToString();

            //name2 = PlayerPrefs.GetString("NHigscore2");
            //_Name2.text = name2;


            Hscore1 = PlayerPrefs.GetInt("HighScore1");
            _Hscore1.text = Hscore1.ToString();

            //name1 = PlayerPrefs.GetString("NHigscore1");
            //_Name1.text = name1;

        }

        else if (score > PlayerPrefs.GetInt("HighScore4") && score <= PlayerPrefs.GetInt("HighScore3"))
        {
            //WinnerNameTab.SetActive(true);

            //Position 4 devient 5
            Hscore5 = PlayerPrefs.GetInt("HighScore4");
            PlayerPrefs.SetInt("HighScore5", Hscore5);
            _Hscore5.text = Hscore5.ToString();

            //name5 = PlayerPrefs.GetString("NHigscore4");
            //PlayerPrefs.SetString("NHighScore5", name5);
            //_Name5.text = name5;


            //Changement de position 4
            Hscore4 = score;
            PlayerPrefs.SetInt("HighScore4", Hscore4);
            _Hscore4.text = score.ToString();

            //name4 = theName;
            //PlayerPrefs.SetString("NHighScore4", name4);
            //_Name4.text = name4;


            Hscore3 = PlayerPrefs.GetInt("HighScore3");
            _Hscore3.text = Hscore3.ToString();

            //name3 = PlayerPrefs.GetString("NHigscore3");
            //_Name3.text = name3;


            Hscore2 = PlayerPrefs.GetInt("HighScore2");
            _Hscore2.text = Hscore2.ToString();

            //name2 = PlayerPrefs.GetString("NHigscore2");
            //_Name2.text = name2;


            Hscore1 = PlayerPrefs.GetInt("HighScore1");
            _Hscore1.text = Hscore1.ToString();

            //name1 = PlayerPrefs.GetString("NHigscore1");
            //_Name1.text = name1;

        }

        else if (score > PlayerPrefs.GetInt("HighScore5") && score <= PlayerPrefs.GetInt("HighScore4"))
        {
            //WinnerNameTab.SetActive(true);

            //Changement de position 5
            Hscore5 = score;
            PlayerPrefs.SetInt("HighScore5", score);
            _Hscore5.text = score.ToString();

            //name5 = theName;
            //PlayerPrefs.SetString("NHighScore5", name5);
            //_Name5.text = name5;


            Hscore4 = PlayerPrefs.GetInt("HighScore4");
            _Hscore4.text = Hscore4.ToString();

            //name4 = PlayerPrefs.GetString("NHigscore4");
            //_Name4.text = name4;


            Hscore3 = PlayerPrefs.GetInt("HighScore3");
            _Hscore3.text = Hscore3.ToString();

            //name3 = PlayerPrefs.GetString("NHigscore3");
            //_Name3.text = name3;


            Hscore2 = PlayerPrefs.GetInt("HighScore2");
            _Hscore2.text = Hscore2.ToString();

            //name2 = PlayerPrefs.GetString("NHigscore2");
            //_Name2.text = name2;


            Hscore1 = PlayerPrefs.GetInt("HighScore1");
            _Hscore1.text = Hscore1.ToString();

            //name1 = PlayerPrefs.GetString("NHigscore1");
            //_Name1.text = name1;
        }
        else
        {
            Hscore5 = PlayerPrefs.GetInt("HighScore5");
            _Hscore5.text = Hscore5.ToString();

            //name5 = PlayerPrefs.GetString("NHigscore5");
            //_Name5.text = name5;

            Hscore4 = PlayerPrefs.GetInt("HighScore4");
            _Hscore4.text = Hscore4.ToString();

            //name4 = PlayerPrefs.GetString("NHigscore4");
            //_Name4.text = name4;


            Hscore3 = PlayerPrefs.GetInt("HighScore3");
            _Hscore3.text = Hscore3.ToString();

            //name3 = PlayerPrefs.GetString("NHigscore3");
            //_Name3.text = name3;


            Hscore2 = PlayerPrefs.GetInt("HighScore2");
            _Hscore2.text = Hscore2.ToString();

            //name2 = PlayerPrefs.GetString("NHigscore2");
            //_Name2.text = name2;


            Hscore1 = PlayerPrefs.GetInt("HighScore1");
            _Hscore1.text = Hscore1.ToString();

            //name1 = PlayerPrefs.GetString("NHigscore1");
            //_Name1.text = name1;
        }
    }

    

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;

    }

    public void closeTab()
    {
        WinnerNameTab.SetActive(false);
    }

        
}


