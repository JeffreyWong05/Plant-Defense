using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrowVine : MonoBehaviour  
{
    private float timer;
    public GameObject vineLevel1; 
    public GameObject vineLevel2;
    public GameObject vineLevel3; 
    public GameObject vineLevel4; 
    public GameObject vineLevel5;
    private int stage = 1; 

    public void waterGrowth()
    {
        Debug.Log("vine grows");
        timer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {//make the first stage visible and all others invisible
        vineLevel2.SetActive(false);
        vineLevel3.SetActive(false);
        vineLevel4.SetActive(false);
        vineLevel5.SetActive(false);
        vineLevel1.SetActive(true);
        timer = Random.Range(20, 31);
    }

    // Update is called once per frame
    //check if timer is at or below 0
    void Update()
    {
        if (stage == 1){   
            if (timer <= 0) {
                stage = 2; //change stage number so this is not repeated
                vineLevel1.SetActive(false); //hide previous vine
                vineLevel2.SetActive(true); //show next vine
                timer = Random.Range(23, 33); //needed to put timer here so it wouldn't keep resetting
            } 
            else { 
                timer -= Time.deltaTime; 
            }
        } //copy-paste for each vine stage

        else if (stage == 2){
            if (timer <= 0) {
                stage = 3;
                vineLevel2.SetActive(false);
                vineLevel3.SetActive(true);
                timer = Random.Range(25, 37);
            }
            else {
                timer -= Time.deltaTime;
            }
        }
        

        else if (stage == 3){
            if (timer <= 0) {
                stage = 4;
                vineLevel3.SetActive(false);
                vineLevel4.SetActive(true);
                timer = Random.Range(28, 41);
            }
            else {
                timer -= Time.deltaTime;
            }
        }
        

        else if (stage == 4){
            if (timer <= 0) {
                stage = 5;
                vineLevel4.SetActive(false);
                vineLevel5.SetActive(true);
                timer = Random.Range(30, 43);
            }
        else {
            timer -= Time.deltaTime;
            }
        }
        
        else if (stage == 5) {
            Debug.Log("Congratulations, the plant is fully grown!");
            stage = 6; //change so that winning message isn't output every frame
            SceneManager.LoadScene("Winner");
        }
    }  
} 