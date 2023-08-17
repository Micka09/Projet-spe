using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DegatPieges : MonoBehaviour

{

    public int degatDeCollision = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            VieDuJoueur vie = collision.transform.GetComponent<VieDuJoueur>();
            vie.perdreVie(degatDeCollision);
        }
    }
}
