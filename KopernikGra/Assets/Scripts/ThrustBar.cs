using UnityEngine;
using UnityEngine.UI;

public class ThrustBar : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] GameObject[] lives;
    [SerializeField] ArcadeRocket arcadeRocket;

    void Update()
    {
        float fillAmount = arcadeRocket.currentThrust / arcadeRocket.maxThrust;
        bar.fillAmount = fillAmount;
        ShowLives();
    }

    void ShowLives()
    {
        if(arcadeRocket.lives == 3)
        {
            lives[0].SetActive(true);
            lives[1].SetActive(true);
            lives[2].SetActive(true);
        }
        else if(arcadeRocket.lives == 2)
        {
            lives[0].SetActive(true);
            lives[1].SetActive(true);
            lives[2].SetActive(false);
        }
        else if(arcadeRocket.lives == 1)
        {
            lives[0].SetActive(true);
            lives[1].SetActive(false);
            lives[2].SetActive(false);
        }
        else
        {
            lives[0].SetActive(false);
            lives[1].SetActive(false);
            lives[2].SetActive(false);
        }
    }
}
