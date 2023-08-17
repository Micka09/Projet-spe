
using UnityEngine;

public class GestionSceneActuel : MonoBehaviour
{

    public bool JoueurPresentParDefault = false;
    

    public static GestionSceneActuel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GestionSceneActuel dans la scène");
            return;
        }

        instance = this;
    }

}
