using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenLoader :  ISceenLoader
{
    public async Task LoadAsync(SceneEnum scene)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        while (!asyncOperation.isDone)
        {
            await Task.Yield();
        }
    }
}



