using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrouilleEnnemi : MonoBehaviour
{

    public float vitesse;
    public Transform[] pointchemin;

    public int degatDeCollision = 10;

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
        transform.Translate(dir.normalized* vitesse* Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position,cible.position) < 0.3f)
        {
            pointDestination =(pointDestination + 1 )% pointchemin.Length;
            cible = pointchemin[pointDestination];

        
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            VieDuJoueur vie = collision.transform.GetComponent<VieDuJoueur>();
            vie.perdreVie(degatDeCollision);
        }
    }

}
