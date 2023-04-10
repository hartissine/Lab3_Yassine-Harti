using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;

    private bool _enPause;
    private bool _partieCommence = false;
    private GestionJeu _gestionJeu;


    private void Start()
    {
        
        _gestionJeu = FindObjectOfType<GestionJeu>();
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
        float temps = Time.time - _gestionJeu.GetTempsDepart() - _gestionJeu.GetTempsInnactif();
        _txtTemps.text = "Temps : " + temps.ToString("f2");
        }

        _txtAccrochages.text = "Accrochages : " + _gestionJeu.GetPointage();
        Time.timeScale = 1;
        _enPause = false;
    }


    private void Update()
    {
        if (_partieCommence)
        {
            float temps = Time.time - _gestionJeu.GetTempsDepart() - _gestionJeu.GetTempsInnactif();
            _txtTemps.text = "Temps : " + temps.ToString("f2");
        }

        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void ChangerPointage(int p_pointage)
    {
        _txtAccrochages.text = "Accrochages : " + p_pointage.ToString();
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }

    public void SetDebutPartie() 
    {
        _partieCommence = true;   
    }
}
