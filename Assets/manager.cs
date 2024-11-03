using UnityEngine;
using UnityEngine.SceneManagement;
public class manager : MonoBehaviour
{
    
    public void start(){
        SceneManager.LoadScene(1);
    }
    public void ext(){
        Application.Quit();
    }
}
