using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollideControl : MonoBehaviour
{
    public AudioClip ballCollision;
    public AudioClip edgeCollision;
    public Rigidbody ball;
    AudioSource audioSource;
    AudioMixer audioMixer;
    AudioMixerGroup[] audioMixGroup;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioMixer = Resources.Load<AudioMixer>("MainMixer");
        audioMixGroup = audioMixer.FindMatchingGroups("Master");

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ground")
        {
            audioSource.playOnAwake = false;
            audioSource.outputAudioMixerGroup = audioMixGroup[0];
            audioSource.volume = ball.velocity.magnitude / 10;

            if (collision.gameObject.tag == "Ball")
            {
                audioSource.clip = ballCollision;
            }
            if (collision.gameObject.tag == "Edge")
            {
                audioSource.clip = edgeCollision;
            }
            audioSource.Play();
        }
    }
}
