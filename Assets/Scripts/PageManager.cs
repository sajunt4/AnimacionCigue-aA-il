using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class PageManager : MonoBehaviour
{
    [SerializeField] CinemachineBrain brain;
    [SerializeField] List<CinemachineVirtualCamera> scenes = new List<CinemachineVirtualCamera>();

    int currentScene = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (brain == null) brain = Camera.main.gameObject.GetComponent<CinemachineBrain>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentScene--;
            if (currentScene < 0)
            {
                currentScene = 0;
                return;
            }

            SwitchCamera(scenes[currentScene]);

        } else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentScene++;
            if (currentScene >= scenes.Count) {
                currentScene = scenes.Count - 1; 
                return;
            }

            SwitchCamera(scenes[currentScene]);

        }
    }

    private void SwitchCamera(CinemachineVirtualCamera cam)
    {
        foreach(CinemachineVirtualCamera c in scenes)
        {
            c.Priority = 0;
        }

        cam.Priority = 1;

        PlayableDirector dir = cam.GetComponent<PlayableDirector>();
        if (dir != null) dir.Play();
    }

    public void NextPage()
    {
        currentScene++;
    }
}
