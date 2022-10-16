using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private Image[] hearts;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    public void UpdateHealth()
    {
        if (playerHealth <= 0)
        {
            Vector3 pos = new Vector3(0,0,0);
            Instantiate(gameOver, pos, transform.rotation);
        }

        for (int i=0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }
}
