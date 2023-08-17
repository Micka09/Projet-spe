using UnityEngine.SceneManagement;
using UnityEngine;

public class ANePasDetruire : MonoBehaviour
{

    public GameObject[] objets;

    public static ANePasDetruire instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ANePasDetruire dans la scène");
            return;
        }

        instance = this;

        foreach (var objet in objets)
        {
            DontDestroyOnLoad(objet);
        }
    }

    public void AnnulerDontDestroyOnLoad()
    {

        foreach (var objet in objets)
        {
            SceneManager.MoveGameObjectToScene(objet, SceneManager.GetActiveScene());
        }

    }
}
