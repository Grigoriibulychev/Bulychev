using UnityEngine;

public class SoundPad : MonoBehaviour
{
    [SerializeField] public AudioSource Get;
    [SerializeField] public AudioSource Out;
    [SerializeField] public AudioSource Attack;

    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}
