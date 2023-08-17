
using UnityEngine;

public class SuiviDeCamera : MonoBehaviour
{

    public GameObject joueur;
    public float temps;
    public Vector3 pos;

    private Vector3 velocite;

    void Update()
    {


        transform.position = Vector3.SmoothDamp(transform.position, joueur.transform.position + pos, ref velocite, temps);


    }
}