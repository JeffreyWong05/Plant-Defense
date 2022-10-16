using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    private Rigidbody2D rb;

    private float waterTimer = 0;
    public float waterDur=0.2f;

    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public LayerMask plantLayer;

    public int attackDamage = 40;

    public int equippedCan = 0;

    public static int health=5;
    public static int waterContained = 1;

    public AudioSource Water;
    public AudioSource Spray;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if player dies
        if (health <= 0)
        {
            Debug.Log("Game over");
            //load start scene
            SceneManager.LoadScene("GameOver");
        }

        //move left or right
        float dirX = Input.GetAxisRaw("Horizontal");

        if (dirX <= -0.1)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        else if (dirX >= 0.1){
            transform.localScale = new Vector3(2f, 2f, 1f);
        }

        rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);

        //Jump
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(0, 9f, 0);
        }

        //spray water
        if (waterTimer >= 0) {
            waterTimer -= Time.deltaTime;
            
        }
        else {
            
            if(equippedCan == 0)
                animator.SetInteger("attackWater", 0);
            
            if(equippedCan == 1)
                animator.SetInteger("attackSpray", 0);
            
        }

        if (Input.GetKeyDown("l") && waterTimer <= 0 && equippedCan == 0 && waterContained > 0)
        {
            Water.Play();
            waterTimer = waterDur;
            animator.SetInteger("attackWater", 1);

            waterContained -= 1;

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, plantLayer);

            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<GrowVine>().waterGrowth();
            }
        }

        //Switch from water to bug spray can
        if (Input.GetKeyDown(","))
        {
            if (equippedCan == 0) {
                equippedCan = 1;
                animator.SetInteger("EquipCan", 1);
            }
            else if (equippedCan == 1) {
                equippedCan = 0;
                animator.SetInteger("EquipCan", 0);
            }
            
        }
        //Attack with spray can
        if (Input.GetKeyDown("l") && waterTimer <= 0 && equippedCan == 1)
        {
            Spray.Play();
            waterTimer = waterDur;
            animator.SetInteger("attackSpray", 1);

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
                enemy.GetComponent<enemyHealth>().TakeDamage(200);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    
}


