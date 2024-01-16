using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    [SerializeField] private int _CastleLife = 30;
    [SerializeField] private GameObject _explosionPrefab = default;

    private UIManager _uiManager;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        healthBar.setMaxHealth(_CastleLife);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /**************************************
     * R�le: G�rer la perte de vie du ch�teau
     **************************************/
    public void Dommage()
    {
        _CastleLife -= 1;
        healthBar.SetHealth(_CastleLife);

        if (_CastleLife < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _uiManager.GameOverSequence();
        }
    }

    
}
