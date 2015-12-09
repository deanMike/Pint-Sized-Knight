using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject Enemy;
    public GameObject Character;
    private GameObject PauseOverlay;
    private bool paused;

    public int maxTotalEnemies;
    public int maxEnemiesOnScreen;
    private int currEnemiesOnScreen;
    private int currTotalEnemies;

    public GameObject panel;

    public GameObject instruct;

    private VariableController variables;

    // Use this for initialization
    void Awake() {
        DontDestroyOnLoad(gameObject);
        PauseOverlay = GameObject.Find("Pause");
        PauseOverlay.SetActive(false);
    }
    void Start() {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
    }

    // Update is called once per frame
    void Update() {
        if (variables.gameStart && instruct != null) {
            instruct.SetActive(true);
        }
        Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0 || Input.GetKeyDown(KeyCode.End)) && Application.loadedLevel == 1) {
            Application.LoadLevel(2);
            Character.transform.position = new Vector2(-4.92f, 20.04f);

        }
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length == 0 || Input.GetKeyDown(KeyCode.End)) && Application.loadedLevel == 2) {
            Application.LoadLevel(3);
            Character.transform.position = new Vector2(0.7892538f, -8.363836f);

        }
        if (Application.loadedLevel == 2) {
            SpawnEnemies();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Pause();
        }
        if (Application.loadedLevel != 1) {
            variables.gameStart = true;
        }
        if (variables.win) {
            panel.SetActive(true);
        }
    }

    void SpawnEnemies() {
        while (GameObject.FindGameObjectsWithTag("Enemy").Length != maxEnemiesOnScreen && currTotalEnemies < maxTotalEnemies) {
            Debug.Log("1 " + (GameObject.FindGameObjectsWithTag("Enemy").Length != maxEnemiesOnScreen));
            Debug.Log("2 " + (currTotalEnemies < maxTotalEnemies));
            Instantiate(Enemy, new Vector3(Random.Range(-10, 10), Random.Range(-20, 20)), new Quaternion());
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
