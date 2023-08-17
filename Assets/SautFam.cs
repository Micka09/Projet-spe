
using UnityEngine;

public class SautFam : MonoBehaviour
{
    public float forceDeSaut;
    public bool auSol;

    public Transform contactAuSol;
    public float verifAuSolRad;
    public LayerMask collision;

    public Rigidbody2D rb;
    public SpriteRenderer sprite;
   
 

    public static SautFam instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de MouvementJoueur dans la sc�ne");
            return;
        }
        instance = this;
    }

    void Update()

    {
        auSol = Physics2D.OverlapCircle(contactAuSol.position, verifAuSolRad, collision);

        if (auSol)
        {

            rb.AddForce(new Vector2(0f, forceDeSaut));

        }

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(contactAuSol.position, verifAuSolRad);

    }
}
