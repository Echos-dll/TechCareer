using Player;
using ScriptableObjects;
using UnityEngine;

public class Healer : MonoBehaviour, IParticlePlayer
{
    [SerializeField] private int _healAmount = 1;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ScriptableAudio healAudio;
    [SerializeField] private AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out HealthComponent health))
        {
            health.Heal(_healAmount);
            PlayParticle();
            healAudio.Play(AudioSource);
        }
        else
        {
            Debug.Log("There is no health component on this gameobject.");
        }
    }

    public void PlayParticle()
    {
        _particleSystem.Play();
    }
}