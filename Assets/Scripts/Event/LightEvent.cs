using System.Collections;
using UnityEngine;

public class LightEvent : MonoBehaviour
{
    [SerializeField] Light LightRadius;
    public float Radius;
    public bool played=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && played==false)
        {
            played = true;
            StartCoroutine(Event());
        }
    }

    IEnumerator Event()
    {
        float StartAngle=LightRadius.spotAngle;
        float time = 0f;
        while (time < 2.0f)
        {
            LightRadius.spotAngle = Mathf.Lerp(StartAngle,Radius,time/2.0f);
            time += Time.deltaTime;
            yield return null;
        }
        LightRadius.spotAngle = Radius;
    }
}
