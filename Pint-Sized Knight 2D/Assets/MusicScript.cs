using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


    private AudioSource music;
    private bool woodsPlay;
    private bool fanfarePlay;

    public AudioClip woods;
    public AudioClip fanfare;
    public AudioClip roar;

    private VariableController variables;
    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        Invoke("FadeIn", 5.0f);
        woodsPlay = true;
        fanfarePlay = true;
        if (Application.loadedLevel == 1) {
            variables = GameObject.Find("Variables").GetComponent<VariableController>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (Application.loadedLevel == 2 && woodsPlay) {
            music.clip = woods;
            Invoke("FadeIn", 5.0f);
            woodsPlay = false;
        }
        if (Application.loadedLevel == 3 && fanfarePlay && variables.win) {
            music.clip = roar;
            FadeIn();
            fanfarePlay = false;
            Invoke("LionRoar", music.clip.length);
        }
    }
    public void FadeOut() {
        while (music.volume > 0) {
            music.volume -= (Time.deltaTime / 3.0f);
        }
    }
    public void FadeIn() {
        music.Play();
    }
    public void LionRoar() {
        music.clip = fanfare;
        music.loop = false;
        FadeIn();
    }
}
