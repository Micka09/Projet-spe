using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject fenetreParametre;

    public string niveauACharger;
    public void LancerLeJeu()
    {
        SceneManager.LoadScene(niveauACharger);

    }

    public void BoutonParametres()
    {
        fenetreParametre.SetActive(true);

    }

    public void QuitterJeu()
    {
        Application.Quit();

    }

    public void FermerParametre()
    {
        fenetreParametre.SetActive(false);
    }


}
