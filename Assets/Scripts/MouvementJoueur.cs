
using UnityEngine;

public class MouvementJoueur : MonoBehaviour
{
    public float vitesse;
    public float forceDeSaut;

    
    public bool enSaut;
    public bool auSol;

    public Transform contactAuSol;
    public float verifAuSolRad;
    public LayerMask collision;

    public Rigidbody2D rb;
    public Animator animation;
    public SpriteRenderer sprite;
    private Vector3 velocite = Vector3.zero;
    public CapsuleCollider2D capsule;

    public static MouvementJoueur instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de MouvementJoueur dans la scène");
            return;
        }
        instance = this;
    }

    void Update()

    {
        auSol = Physics2D.OverlapCircle(contactAuSol.position, verifAuSolRad, collision);

        if (Input.GetButtonDown("Jump") && auSol)
        {

            enSaut = true;
        }

    }

    void FixedUpdate()
    {

        float mouvementHorizontal = Input.GetAxis("Horizontal") * vitesse * Time.deltaTime;

        MouvementDuJoueur(mouvementHorizontal);

        Regard(rb.velocity.x);


        float vitessePerso = Mathf.Abs(rb.velocity.x);
        animation.SetFloat("vitesse", vitessePerso);


    }

    void MouvementDuJoueur(float parametre)
    {
        Vector3 velociteCible = new Vector2(parametre, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, velociteCible, ref velocite, 0.05f);

        if(enSaut == true) {

            rb.AddForce(new Vector2(0f, forceDeSaut));

            enSaut= false;

        }     

    }

    void Regard(float regard)
    {
        if(regard > 0.1f)

        {
            sprite.flipX=false;

        }
        else if(regard < -0.1f)

        {
            sprite.flipX=true;
        }
 
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(contactAuSol.position, verifAuSolRad);

    }
}
