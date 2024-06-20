using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _settutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TutorialManager.instance.setTutorial();
    }
}
