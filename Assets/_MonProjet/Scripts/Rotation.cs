using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // ***** Attributs *****

    [SerializeField] private float _vitesseRotation = 1.5f;  // �tabli la vitesse de rotation du gameObject 

    void FixedUpdate()
    {
        transform.Rotate(0f, _vitesseRotation, 0f);  // �tabli une rotation du gameObject autour de l'axe des Y
    }
}
