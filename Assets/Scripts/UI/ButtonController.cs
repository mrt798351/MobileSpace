using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName)
    {
        FadeCanvas.fader.FaderLoadString(levelName);
    }
    
    public void LoadLevelInt(int levelIndex)
    {
        FadeCanvas.fader.FadeLoadInt(levelIndex);
    }

    public void RestartLevel()
    {
        FadeCanvas.fader.FadeLoadInt(SceneManager.GetActiveScene().buildIndex);
    }
}
