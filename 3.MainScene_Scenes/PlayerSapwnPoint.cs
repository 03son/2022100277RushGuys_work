using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSapwnPoint : MonoBehaviour
{
    public static PlayerSapwnPoint instance;

    public GameObject Player;

    public GameObject PlayerCharacter;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        float CharScale;
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            CharScale = 1;
        }
        else
        {
            CharScale = 0.3f;
        }

        if (PlayerCharacter != null)
        {
            Destroy(PlayerCharacter);
        }
        PlayerCharacter = Instantiate(Player);
        PlayerCharacter.transform.position = gameObject.transform.position;
        PlayerCharacter.transform.rotation = gameObject.transform.rotation;
        PlayerCharacter.transform.localScale = new Vector3(CharScale, CharScale, CharScale);
    }
}
