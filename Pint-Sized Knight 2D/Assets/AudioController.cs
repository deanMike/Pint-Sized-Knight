using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    public AudioClip[] sounds;
    private AudioSource sound;
    public VariableController variables;
	// Use this for initialization
	void Start () {
        sound = gameObject.GetComponent<AudioSource>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
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
        Invoke("attackFalse", sound.clip.length);
        
    }
    public void playDefendSound()
    {
        sound.clip = sounds[0];
        if (!sound.isPlaying)
            sound.Play();
        Invoke("defendFalse", sound.clip.length);
    }
    private void attackFalse()
    {
        variables.attack = false;
    }
    private void defendFalse()
    {
        variables.defend = false;
    }
}
