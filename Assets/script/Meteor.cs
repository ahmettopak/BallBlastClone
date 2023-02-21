using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Meteor : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected int health;

    [SerializeField] protected TMP_Text textHealth;
    [SerializeField] protected float jumpForce;

    protected bool isShowing;
    protected float[] leftAndRight=new float[2]{-1f,1f};
    [HideInInspector] public bool isResultofFission=true;

    void Start()
    {
        UpdateHealthUI();
        isShowing=true;
        rb.gravityScale=0f;

        if(isResultofFission)
        {
           FallDown();
        }
        else{
           float direction=leftAndRight[Random.Range(0,2)];
            float screeoffset=Game.Instance.screenWidth*1.5f;
            transform.position=new Vector2(screeoffset*direction,transform.position.y);

            rb.velocity=new Vector2(-direction , 0f);
            Invoke("FallDown" , Random.Range(screeoffset-2.5f , screeoffset-1f));
        }

        
    }
    void FallDown()
    {
        isShowing=false;
        rb.gravityScale=1f;
        rb.AddTorque(Random.Range(-20f,20f));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("cannon"))
        {
            MeteorSpawner.Instance.lose();
        }
        else if(other.tag.Equals("missile"))
        {
           TakeDamage(1);
           MeteorSpawner.Instance.scorex();
           Missiles.Instance.DestroyMissile(other.gameObject);
        }
        else if(!isShowing && other.tag.Equals("wall"))
        {
            float posX=transform.position.x;
            if(posX>0)
            {
               rb.AddForce(Vector2.left*150f);
            }
            else{
               rb.AddForce(Vector2.right*150f);
            }

             rb.AddTorque(posX*4f);
        }
        else if(other.tag.Equals("ground"))
        {
            rb.velocity=new Vector2(rb.velocity.x , jumpForce);
             rb.AddTorque(-rb.angularVelocity*4f);
        }
    }
    public void TakeDamage(int damage)
    {
        if(health>1)
        {
            health -=damage;
        }
        else
        {
            Die();
        }
         UpdateHealthUI();
    }
    virtual protected void Die()
    {
         Destroy(gameObject);
    }
    protected void UpdateHealthUI()
    {
        textHealth.text=health.ToString();
    }
}
