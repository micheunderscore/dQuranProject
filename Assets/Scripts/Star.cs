using UnityEngine;

public class Star : MonoBehaviour {
    public int score = 0;
    public GameObject star1, star2, star3;

    void Update() {
        star1.SetActive(score > 0);
        star2.SetActive(score > 1);
        star3.SetActive(score == 3);
    }
}
