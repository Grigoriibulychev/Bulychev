using System.Collections;
//using UltimateXR.Animation.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image HealthBar;
    [SerializeField] HealthCount Player;
    Coroutine HealthCoroutine;
    //float targetFill;
    public void ChangeHPBar()
    {
        if (AnimateHealthBar() != null)
        {
            StopCoroutine(AnimateHealthBar());
        }
        HealthCoroutine = StartCoroutine(AnimateHealthBar());
        //HealthBar.fillAmount = Player.health / 100;
        //targetFill = (float)Player.health / 100;
        //Mathf.Lerp(HealthBar.fillAmount, targetFill, 0.1f);
    }

    IEnumerator AnimateHealthBar()
    {
        float targetFill = (float)Player.health / 100;
        float currentFill = HealthBar.fillAmount;
        float animationDuration = 0.3f;
        float elapsedTime = 0f;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            HealthBar.fillAmount = Mathf.Lerp(currentFill, targetFill, elapsedTime / animationDuration);
            yield return null;
        }
        HealthBar.fillAmount = targetFill;
    }
}
