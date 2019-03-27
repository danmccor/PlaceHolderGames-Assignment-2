using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
    public GameObject setOn;
    public void SettingOpen()
    {
        setOn.SetActive(true);
    }

    public void SettingClose()
    {
        setOn.SetActive(false);
    }

    public void Closer()
    {
        Application.Quit();
    }
}
