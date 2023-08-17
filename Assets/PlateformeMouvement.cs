using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouvement : MonoBehaviour
{

    public float vitesse;
    public Transform[] pointchemin;


    private Transform cible;
    private int pointDestination;


    // Start is called before the first frame update
    void Start()
    {

        cible = pointchemin[0];

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = cible.position - transform.position;
        transform.Translate(dir.normalized * vitesse * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, cible.position) < 0.3f)
        {
            pointDestination = (pointDestination + 1) % pointchemin.Length;
            cible = pointchemin[pointDestination];


        }

    }

    

}
