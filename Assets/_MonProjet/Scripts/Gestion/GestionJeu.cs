using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    // ***** Attributs *****

    private int _pointage = 0;  
    private float _tempsDepart = 0;
    private float _tempsFinal = 0;

    private void Awake()
    {
        // Vérifie si un gameObject GestionJeu est déjà présent sur la scène si oui
        // on détruit celui qui vient d'être ajouté. Sinon on le conserve pour le 
        // scène suivante.

        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _tempsDepart = Time.time;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 0)
        {
            Destroy(gameObject);
        }
    }

    /*
   * Méthode publique qui permet d'augmenter le pointage de 1
   */
    public void AugmenterPointage()
    {
        _pointage++;
        UIManager uiManager = FindObjectOfType<UIManager>();
        uiManager.ChangerPointage(_pointage);
    }

    // Accesseur qui retourne la valeur de l'attribut pointage
    public int GetPointage()
    {
        return _pointage;
    }

    public float GetTempsDepart()
    {
        return _tempsDepart;
    }


    public void SetTempsFinal(float p_tempFinal)
    {
        _tempsFinal = p_tempFinal - _tempsDepart;
    }

    public float GetTempsFinal()
    {
        return _tempsFinal;
    }

    /**********************************************************************************************  
    //private int _accrochageNiveau1 = 0;  
    //private float _tempsNiveau1 = 0.0f;      
    //private int _accrochageNiveau2 = 0;  
    //private float _tempsNiveau2 = 0.0f;      
    //private int _accrochageNiveau3 = 0;  
    //private float _tempsNiveau3 = 0.0f;
    //// Accesseur qui retourne le temps pour le niveau 1

    //public float GetTempsNiv1()
    //{
    //    return _tempsNiveau1;
    //}

    //// Accesseur qui retourne le nombre d'accrochages pour le niveau 1

    //public int GetAccrochagesNiv1()
    //{
    //    return _accrochageNiveau1;
    //}
    //// Accesseur qui retourne le temps pour le niveau 2

    //public float GetTempsNiv2()
    //{
    //    return _tempsNiveau2;
    //}

    //// Accesseur qui retourne le nombre d'accrochages pour le niveau 2

    //public int GetAccrochagesNiv2()
    //{
    //    return _accrochageNiveau2;
    //}
    //// Accesseur qui retourne le temps pour le niveau 3

    //public float GetTempsNiv3()
    //{
    //    return _tempsNiveau3;
    //}

    //// Accesseur qui retourne le nombre d'accrochages pour le niveau 3

    //public int GetAccrochagesNiv3()
    //{
    //    return _accrochageNiveau3;
    //}
    //// Méthode qui reçoit les valeurs pour le niveau 1 et qui modifie les attributs respectifs

    //public void SetNiveau1(int accrochages, float tempsNiv1)
    //{
    //    _pointage = 0;
    //    _accrochageNiveau1 = accrochages;
    //    _tempsNiveau1 = tempsNiv1;
    //}
    //// Méthode qui reçoit les valeurs pour le niveau 2 et qui modifie les attributs respectifs

    //public void SetNiveau2(int accrochages, float tempsNiv2)
    //{
    //    _pointage = 0;
    //    _accrochageNiveau2 = accrochages;
    //    _tempsNiveau2 = tempsNiv2 - _tempsNiveau1;
    //}
    //// Méthode qui reçoit les valeurs pour le niveau 3 et qui modifie les attributs respectifs

    //public void SetNiveau3(int accrochages, float tempsNiv3)
    //{
    //    _pointage = 0;
    //    _accrochageNiveau3 = accrochages;
    //    _tempsNiveau3 = tempsNiv3 - _tempsNiveau2 - _tempsNiveau1;
    //}

    **********************************************************************************************/
}