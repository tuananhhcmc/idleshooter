using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip reloadClip;
    [SerializeField] private AudioClip energyClip;

    public void PLayShootSound()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }

    public void PLayReloadSound()
    {
        effectAudioSource.PlayOneShot(reloadClip);
    }

    public void PLayEnergySound()
    {
        effectAudioSource.PlayOneShot(energyClip);
    }
    public void PlayDefaultAudio()
    {
        bossAudioSource.Stop();
        defaultAudioSource.Play();
    }
    public void PlayBossAudio()
    {
        bossAudioSource.Play();
        defaultAudioSource.Stop();
    }
    public void StopAudioGame()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Stop();
        effectAudioSource.Stop();
    }
}
