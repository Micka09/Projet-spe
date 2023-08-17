using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool jeuEnPause = false;
    public GameObject pauseMenuBouton;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (jeuEnPause) 
            {
                Reprendre();
            }
            else
            {
                Pause();
            }
        }
        
    }

    void Pause()
    
    {
        pauseMenuBouton.SetActive(true);
        Time.timeScale = 0;
        jeuEnPause= true;
        
    }

    public void Reprendre()
    {

        pauseMenuBouton.SetActive(false);
        Time.timeScale = 1;
        jeuEnPause = false;

    }

    public void ChargerMenu() 
    {
        ANePasDetruire.instance.AnnulerDontDestroyOnLoad();
        Reprendre();
        SceneManager.LoadScene("MenuPrincipal");

    }

}
