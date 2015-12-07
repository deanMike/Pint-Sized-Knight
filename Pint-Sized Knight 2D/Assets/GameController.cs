using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject Enemy;
    private GameObject PauseOverlay;
    private bool paused;

    public int maxTotalEnemies;
    public int maxEnemiesOnScreen;
    private int currEnemiesOnScreen;
    private int currTotalEnemies;

    // Use this for initialization
    void Awake() {
        DontDestroyOnLoad(gameObject);
        PauseOverlay = GameObject.Find("Pause");
        PauseOverlay.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0) || Input.GetKeyDown(KeyCode.End) && Application.loadedLevel == 1) {
            Application.LoadLevel(2);
        }
        if (Application.loadedLevel == 2) {
            SpawnEnemies();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
    }

    void SpawnEnemies() {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length != maxEnemiesOnScreen && currTotalEnemies < maxTotalEnemies) {
            Instantiate(Enemy, new Vector3(Random.Range(-25, 25), Random.Range(-25, 25)), new Quaternion());
            currEnemiesOnScreen++;
            currTotalEnemies++;
        }
    }
    void Pause() {
        if (!paused) {
            Time.timeScale = 0;
            PauseOverlay.SetActive(true);
            paused = true;
        } else {
            Time.timeScale = 1;
            PauseOverlay.SetActive(false);
            paused = false;
        }
    }
}
