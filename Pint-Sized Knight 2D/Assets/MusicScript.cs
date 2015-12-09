using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {


    private AudioSource music;
    private bool woodsPlay;

    public AudioClip woods;
    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        Invoke("FadeIn", 5.0f);
        woodsPlay = true;
    }

    // Update is called once per frame
    void Update() {
        if (Application.loadedLevel == 2 && woodsPlay) {
            music.clip = woods;
            Invoke("FadeIn", 5.0f);
            woodsPlay = false;
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
}
