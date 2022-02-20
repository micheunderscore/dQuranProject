using UnityEngine;

public class PanelManager : MonoBehaviour {
    private int activePanel = 0;

    void Update()
    {
        int i = 0;
        foreach (Transform child in transform) {
            child.gameObject.SetActive(i == activePanel);
            i++;
        }
    }

    public void NextPanel () {
        activePanel++;
    }

    public void PrevPanel () {
        activePanel--;
    }
}
