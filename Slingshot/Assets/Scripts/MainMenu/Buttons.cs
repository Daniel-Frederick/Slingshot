using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void StartButton() {
        SceneManager.LoadSceneAsync("Level1");
    }
}
