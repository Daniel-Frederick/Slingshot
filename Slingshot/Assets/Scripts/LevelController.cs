using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static uint spellCount = 0;
    private GoblinController[] goblins;
    private uint levelIndex = 1;


    private void OnEnable()
    {
        goblins = FindObjectsByType<GoblinController>(FindObjectsSortMode.None);
    }

    void Update()
    {
        // This is inefficient - should only go off when a Goblin is destroyed
        foreach (GoblinController goblin in goblins)
        {
            if (goblin != null)
            {
                return;
            }
        }

        levelIndex++;
        SceneManager.LoadScene("Level" + levelIndex);
    }
}
