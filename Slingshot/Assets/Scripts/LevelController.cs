using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private GoblinController[] goblins;

    private void OnEnable()
    {
        goblins = FindObjectsByType<GoblinController>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
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

        // TODO: Should go back to level page
        SceneManager.LoadScene("Level2");
    }
}
