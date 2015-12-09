using UnityEngine;
using System.Collections;

public class TransitionMusic : MonoBehaviour {
    // Use this for initialization
    private AudioSource transMusic;
    void Start() {
        transMusic = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update() {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && Application.loadedLevel != 3) {
            FadeIn();
        }
    }
    public void FadeOut() {
        while (transMusic.volume > 0) {
            transMusic.volume -= (Time.deltaTime / 3.0f);
        }
    }
    public void FadeIn() {
        transMusic.Play();
        //while (audio.volume < 1) {
          //  audio.volume += (Time.deltaTime / 3.0f);
        //}
    }
}
