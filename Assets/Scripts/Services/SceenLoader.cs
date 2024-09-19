using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenLoader :  ISceenLoader
{
    public async Task LoadAsync(SceneEnum scene)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string targetSceneName = scene.ToString();

        if (!currentSceneName.Equals(targetSceneName))
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(targetSceneName);
            while (!asyncOperation.isDone)
            {
                await Task.Yield();
            }
        }
    }
}



