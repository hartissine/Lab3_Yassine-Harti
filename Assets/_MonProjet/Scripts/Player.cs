using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ***** Attributs *****

    [SerializeField] private float _vitesse = 800;
    [SerializeField] private float _rotation = 200;
    private Rigidbody _rb;  // Variable pour emmagasiner le rigidbody du joueur

    private bool _partieCommence = false;

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();   // Récupère le rigidbody du Player
    }
    
    // Ici on utilise FixedUpdate car les mouvements du joueurs implique le déplacement d'un rigidbody
    private void FixedUpdate()
    {        
            MouvementsJoueur();
    }
    /*
     * Méthode qui gère les déplacements du joueur
     */
    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal"); // Récupère la valeur de l'axe horizontal de l'input manager
        float positionZ = Input.GetAxis("Vertical");  // Récupère la valeur de l'axe vertical de l'input manager
        Vector3 direction = new Vector3(positionX, 0f, positionZ);  // Établi la direction du vecteur à appliquer sur le joueur
        _rb.velocity = direction.normalized * Time.fixedDeltaTime * _vitesse;  // Applique la vélocité sur le corps du joueur dans la direction du vecteur

        if (direction != Vector3.zero && !_partieCommence)
        {
            _partieCommence = true;

            GestionJeu gestionJeu = FindObjectOfType<GestionJeu>();
            gestionJeu.SetTempsDepart();

            UIManager uiManager = FindObjectOfType<UIManager>();
            uiManager.SetDebutPartie();
        }

        if (direction.magnitude >=0.1f) // Condition pour gerer la rotation du player
        {
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotation * Time.fixedDeltaTime);
        }
    }

    /*
     * Méthode appelé en fin de partie qui rend le gameObject Player inactif
     */
    public void finPartieJoueur()
    {
        this.gameObject.SetActive(false); // pour faire disparaitre le joueur
    }
}
