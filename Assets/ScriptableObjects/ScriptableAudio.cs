using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Audio", menuName = "ScriptableObjects/New Audio", order = 0)]
    public class ScriptableAudio : ScriptableObject
    {
        public AudioClip clip;

        public void Play(AudioSource source)
        {
            source.clip = clip;
            source.Play();
            Debug.Log("Played audio.");
        }
    }
}