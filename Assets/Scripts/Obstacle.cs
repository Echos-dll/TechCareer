using Player;
using ScriptableObjects;
using UnityEngine;

public class Obstacle : MonoBehaviour, IParticlePlayer
{
    [SerializeField] private int _damageAmount = 1;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private ScriptableAudio damageAudio;
    [SerializeField] private AudioSource AudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out HealthComponent health))
        {
            health.TakeDamage(_damageAmount);
            PlayParticle();
            damageAudio.Play(AudioSource);
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
