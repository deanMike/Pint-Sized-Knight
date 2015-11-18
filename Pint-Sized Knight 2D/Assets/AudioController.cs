using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    public AudioClip[] sounds;
    private AudioSource sound;
    private VariableController variables;
	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        sound = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (variables.attack)
            playAttackSound();
        if (variables.defend)
            playDefendSound();
	}
    public void playAttackSound()
    {
        sound.clip = sounds[new System.Random().Next(1, 4)];
        if (!sound.isPlaying)
            sound.Play();
    }
    public void playDefendSound()
    {
        sound.clip = sounds[0];
        if (!sound.isPlaying)
            sound.Play();
    }
}
