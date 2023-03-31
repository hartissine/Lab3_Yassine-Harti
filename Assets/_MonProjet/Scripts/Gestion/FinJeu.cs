using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJeu : MonoBehaviour
{
    private bool _finPartie = false;  // bool�en qui d�termine si la partie est termin�e
    private GestionJeu _gestionJeu; // attribut qui contient un objet de type GestionJeu
    private Player _player;  // attribut qui contient un objet de type Player

    // ***** M�thode priv�es  *****

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // r�cup�re sur la sc�ne le gameObject de type GestionJeu
        _player = FindObjectOfType<Player>();  // r�cup�re sur la sc�ne le gameObject de type Player
    }

    /*
     * M�thode qui se produit quand il y a collision avec le gameObject de fin
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finPartie)  // Si la collision est produite avec le joueur et la partie n'est pas termin�e
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;  // on change la couleur du mat�riel � vert
            _finPartie = true; // met le bool�en � vrai pour indiquer la fin de la partie
            int noScene = SceneManager.GetActiveScene().buildIndex; // R�cup�re l'index de la sc�ne en cours
            if (noScene == (SceneManager.sceneCountInBuildSettings - 1))  // Si nous somme sur la derni�re sc�ne
            {
                _gestionJeu.SetNiveau3(_gestionJeu.GetPointage(), Time.time);
                float tempsTotalniv1 = _gestionJeu.GetTempsNiv1() + _gestionJeu.GetAccrochagesNiv1();  //Calcul le temps total pour le niveau 1
                float tempsTotalniv2 = _gestionJeu.GetTempsNiv2() + _gestionJeu.GetAccrochagesNiv2(); // Calcul le temps total pour le niveau 2
                float tempsTotalniv3 = _gestionJeu.GetTempsNiv3() + _gestionJeu.GetAccrochagesNiv3(); // Calcul le temps total pour le niveau 3

                // Affichage des r�sultats finaux dans la console
                Debug.Log("Fin de partie !!!!!!!");
                Debug.Log("Le temps pour le niveau 1 est de : " + _gestionJeu.GetTempsNiv1().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroch� au niveau 1 : " + _gestionJeu.GetAccrochagesNiv1() + " obstacles");
                Debug.Log("Temps total niveau 1 : " + tempsTotalniv1.ToString("f2") + " secondes");
                Debug.Log("Le temps pour le niveau 2 est de : " + _gestionJeu.GetTempsNiv2().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroch� au niveau 2 : " + _gestionJeu.GetAccrochagesNiv2() + " obstacles");
                Debug.Log("Temps total niveau 2 : " + tempsTotalniv2.ToString("f2") + " secondes");
                Debug.Log("Le temps pour le niveau 3 est de : " + _gestionJeu.GetTempsNiv3().ToString("f2") + " secondes");
                Debug.Log("Vous avez accroch� au niveau 3 : " + _gestionJeu.GetAccrochagesNiv3() + " obstacles");
                Debug.Log("Temps total niveau 3 : " + tempsTotalniv3.ToString("f2") + " secondes");
                Debug.Log("Le temps total pour les trois niveaux est de : " + (tempsTotalniv1 + tempsTotalniv2 + tempsTotalniv3).ToString("f2") + " secondes");
                Debug.Log("Le Nombres total d'obstacles touch� pour les trois niveaux est de : " + (_gestionJeu.GetAccrochagesNiv1() + _gestionJeu.GetAccrochagesNiv2() + _gestionJeu.GetAccrochagesNiv3()) + " obstacles");


                _player.finPartieJoueur();  // Appeler la m�thode publique dans Player pour d�sactiver le joueur
            }
            else {
                if(noScene == 0)
                    
                // Appelle la m�thode publique dans gestion jeu pour conserver les informations du niveau 1
                _gestionJeu.SetNiveau1(_gestionJeu.GetPointage(), Time.time);
           else if (noScene == 1)
                    // Appelle la m�thode publique dans gestion jeu pour conserver les informations du niveau 2
                    _gestionJeu.SetNiveau2(_gestionJeu.GetPointage(), Time.time);                     
                // Charge la sc�ne suivante
                SceneManager.LoadScene(noScene + 1);}
            
        }
    }
}
