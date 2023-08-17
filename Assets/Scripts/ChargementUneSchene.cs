using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class ChargementUneSchene : MonoBehaviour
{

    public int SceneSuivante;
    public Animator systemeDeFondu;

    private void Start()
    {
        SceneSuivante = SceneManager.GetActiveScene().buildIndex + 1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(chargementSceneSuivante());
        }
    }

    public IEnumerator chargementSceneSuivante()
    {
        systemeDeFondu.SetTrigger("FonduDeb");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneSuivante);

    }
}
