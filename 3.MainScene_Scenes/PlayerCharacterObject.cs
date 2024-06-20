using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerCharacterObject : MonoBehaviour
{
    public static PlayerCharacterObject instance;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            //Destroy(this.gameObject);
        }
    }

}
