using UnityEngine.SceneManagement;
using UnityEngine;

public class GestionDeDefaite : MonoBehaviour
{

    public GameObject defaiteUI;

    public static GestionDeDefaite instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GestionDeDefaite dans la scène");
            return;
        }

        instance = this;
    }

    public void MortDuJoueur()
    {

        if (GestionSceneActuel.instance.JoueurPresentParDefault)
        {
            ANePasDetruire.instance.AnnulerDontDestroyOnLoad();
        }


        defaiteUI.SetActive(true);
    }



    public void BoutonRecommencer()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        VieDuJoueur.instance.Spawn();
        defaiteUI.SetActive(false);
    }

    public void BoutonMenuP() 
    {
        ANePasDetruire.instance.AnnulerDontDestroyOnLoad();
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void BoutonQuitter() 
    { 
    
    Application.Quit();
    
    }
}
