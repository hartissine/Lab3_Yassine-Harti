using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translation2 : MonoBehaviour
{
    // ***** Attributs *****

    public float _vitesse = 30;
    public Vector3 _Offset = new Vector3(-22, 0, 22);// �tabli l'offset de la position du gameObject
    public float _rotation = 180;
    private int _direction = 1;
    
    // ***** M�thodes priv�es *****

    void FixedUpdate()
    {

        if (transform.position.x > _Offset.z) // etalement de la translation sur l'axe des X avec le changement de _direction 
        {
            _direction = -1;
            transform.Rotate(0, _rotation, 0);
        }
        if (transform.position.x < _Offset.x) // etalement de la translation sur l'axe des X avec le changement de _direction 
        {
            _direction = 1;
            transform.Rotate(0, -(_rotation), 0);
        }
        transform.position = transform.position + new Vector3(_vitesse * _direction * Time.deltaTime, 0, 0);    // �tabli une translation du gameObject sur l'axe x
    }
}
