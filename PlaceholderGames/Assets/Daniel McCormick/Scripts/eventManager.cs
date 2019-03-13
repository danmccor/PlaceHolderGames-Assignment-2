using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManager : MonoBehaviour
{
    public List<GameObject> triggers = new List<GameObject>();
    public List<GameObject> events = new List<GameObject>();
    public Dictionary<int,GameObject> eventLinks = new Dictionary<int, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        for(int i = 0; i < triggers.Count; i++)
        {
            eventLinks.Add(triggers[i].GetHashCode(), events[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTrigger(int trigger)
    {
        Debug.Log("God flooded us all");
        if (eventLinks.ContainsKey(trigger))
        {
            eventLinks[trigger].SetActive(true);
        }
        
    }
    
}
