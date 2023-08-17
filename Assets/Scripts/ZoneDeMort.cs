using UnityEngine;
using System.Collections;

public class ZoneDeMort : MonoBehaviour
{


    private Transform departJoueur;
    private Animator fonduSysteme;

    private void Awake()
    {
        departJoueur = GameObject.FindGameObjectWithTag("DepartJoueur").transform;
        fonduSysteme = GameObject.FindGameObjectWithTag("FonduSysteme").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            StartCoroutine(ReplacerJoueur(collision));
                                        
        }
    }

    private IEnumerator ReplacerJoueur(Collider2D collision)
    {
        fonduSysteme.SetTrigger("FonduDeb");
        yield return new WaitForSeconds(1);
        collision.transform.position = departJoueur.position;

    }
}
