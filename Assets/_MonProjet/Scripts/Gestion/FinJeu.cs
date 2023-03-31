using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJeu : MonoBehaviour
{
    private bool _finPartie = false;  // booléen qui détermine si la partie est terminée
    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** Méthode privées  *****

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // récupère sur la scène le gameObject de type GestionJeu
        _player = FindObjectOfType<Player>();  // récupère sur la scène le gameObject de type Player
    }

    /*
     * Méthode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas terminée
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du matériel à vert
            _finPartie = true; // met le booléen à vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // Récupère l'index de la scène en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 1))  // Si nous somme sur la dernière scène
            {
                _gestionJeu.SetNiveau3(_gestionJeu.GetPointage(), Time.time);
                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();  //Calcul le temps total pour le niveau 1
                float tempsTotalniv2 = _gestionJeu.GetTempsNiv2() + _gestionJeu.GetAccrochagesNiv2(); // Calcul le temps total pour le niveau 2
                float tempsTotalniv3 = _gestionJeu.GetTempsNiv3() + _gestionJeu.GetAccrochagesNiv3(); // Calcul le temps total pour le niveau 3

                // Affichage des résultats finaux dans la console
                Debug.Log("Fin de partie !!!!!!!");
                Debug.Log("Le temps pour le niveau 1 est de : " + _gestionJeu.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");
                Debug.Log("Le temps pour le niveau 2 est de : " + _gestionJeu.GetTempsNiv2().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 2 : " + _gestionJeu.GetAccrochagesNiv2() + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");
                Debug.Log("Le temps pour le niveau 3 est de : " + _gestionJeu.GetTempsNiv3().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroché au niveau 3 : " + _gestionJeu.GetAccrochagesNiv3() + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");
                Debug.Log("Le temps total pour les trois niveaux est de : " + (tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3).ToString("f2") + " secondes");
                Debug.Log("Le Nombres total d'obstacles touché pour les trois niveaux est de : " + (_gestionJeu.GetAccrochagesNiv1() + _gestionJeu.GetAccrochagesNiv2() + _gestionJeu.GetAccrochagesNiv3()) + " obstacles");


                _player.finPartieJoueur();  // Appeler la méthode publique dans Player pour désactiver le joueur
            }
            else {
                if(noScene == 0)
                    
                // Appelle la méthode publique dans gestion jeu pour conserver les informations du niveau 1
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
           else if (noScene == 1)
                    // Appelle la méthode publique dans gestion jeu pour conserver les informations du niveau 2
                    _gestionJeu.SetNiveau2(_gestionJeu.GetPointage(), Time.time);                     
                // Charge la scène suivante
                SceneManager.LoadScene(noScene + 1);}
            
        }
    }
}
