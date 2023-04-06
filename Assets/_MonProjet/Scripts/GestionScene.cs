using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{
    [SerializeField] private GameObject _Instructions = default;
    private bool _enInstructions;

    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex; // Récupère l'index de la scène en cours
        SceneManager.LoadScene(noScene + 1);
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }

    public void GestionInstructions()
    {
        if (!_enInstructions)
        {
            _Instructions.SetActive(true);
            _enInstructions = true;
        }
        else if (_enInstructions)
        {
            EnleverInstructions();
        }
    }

    public void EnleverInstructions()
    {
        _Instructions.SetActive(false);
        _enInstructions = false;
    }
}
