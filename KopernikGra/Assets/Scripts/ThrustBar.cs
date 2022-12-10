using UnityEngine;
using UnityEngine.UI;

public class ThrustBar : MonoBehaviour
{
    public Image healthBarImage;
    [SerializeField] ArcadeRocket arcadeRocket;

    void Update()
    {
        float fillAmount = arcadeRocket.maxThrust / arcadeRocket.currentThrust;
        healthBarImage.fillAmount = fillAmount;
    }
}
