
using UnityEngine;
using UnityEngine.UI;

public class BarreDeVie : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image remplissage;

    public void setMaxVie(int vie)
    {
        slider.value= vie;
        slider.maxValue= vie;
        
        remplissage.color = gradient.Evaluate(1f);
        
    }

    public void setVie(int vie)
    {
        slider.value= vie;

        remplissage.color = gradient.Evaluate(slider.normalizedValue);
    }

    
}
