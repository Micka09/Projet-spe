using System.Collections;
using UnityEngine;

public class VieDuJoueur : MonoBehaviour
{
    public int vieMax = 100;
    public int vieActuelle;

    public bool etreInvincible = false;
    public SpriteRenderer graphics;
    public float delaiflash = 0.1f;

    public BarreDeVie barreDeVie;


    public static VieDuJoueur instance;

    private void Awake()
    {
        if(instance !=null)
        {
            Debug.LogWarning("Il y a plus d'une instance de VieDuJoueur dans la scène");
            return;
        }
        
        instance= this;
    }

    void Start()
    {

        vieActuelle= vieMax;
        barreDeVie.setMaxVie(vieMax);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V)) {
            perdreVie(60);
        }

    }

    public void perdreVie(int degat)
    {
        if(!etreInvincible) { 

        vieActuelle -= degat;
        barreDeVie.setVie(vieActuelle);

            if(vieActuelle <= 0 )
            {

                Mort();
                return;

            }

            etreInvincible= true;
            StartCoroutine(flash());
            StartCoroutine(TempsInvicible());

        }
    }

    public void Mort()
    {
        Debug.Log("Le joueur est mort");
        MouvementJoueur.instance.enabled = false;
        MouvementJoueur.instance.animation.SetTrigger("Mort");
        MouvementJoueur.instance.rb.velocity = Vector3.zero;
        MouvementJoueur.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        MouvementJoueur.instance.capsule.enabled= false;
        GestionDeDefaite.instance.MortDuJoueur();

    }
    public void Spawn()
    {
        
        MouvementJoueur.instance.enabled = true;
        MouvementJoueur.instance.animation.SetTrigger("Respawn");
        MouvementJoueur.instance.rb.bodyType = RigidbodyType2D.Dynamic;
        MouvementJoueur.instance.capsule.enabled = true;
        vieActuelle = vieMax;
        barreDeVie.setVie(vieActuelle);

    }

    public IEnumerator flash()
    {
        while (etreInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(delaiflash);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(delaiflash);


        }
    }

    public IEnumerator TempsInvicible()
    {

        yield return new WaitForSeconds(3f);
        etreInvincible = false;
    }
}
