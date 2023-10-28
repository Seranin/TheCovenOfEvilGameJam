 using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
public class playerLogic : MonoBehaviour
{   
    public float hp = 100;  

    public float maxhp = 100;
    public float shield = 50; 
    public float maxShield =50;
    public float damagetaken = 10;

    private bool isTakingDamage = false;
    
    private bool shieldAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shieldregen(){
        shieldAllowed = true;
        shieldCooldown(5);
        if(shieldAllowed)
        {
            shield+=10;
            if(shield> 50)
            {
                shield =50;
            }
        }
    }
    public void dealDamage(float damage)
    {
        float remainingDamage = damage;
        remainingDamage = damage - shield;
        if(shield>0)
        {
            shield-=damage;
            if(remainingDamage<0){remainingDamage = 0;}
        }
        hp -= remainingDamage;
        //insert animation blink here!!!!!!!!
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TrailEnemy")
        {
            if(!isTakingDamage)
            {
                Debug.Log("ahhh i took damage");
                dealDamage(damagetaken);
                isTakingDamage = true;
                shieldAllowed = false;
                StartCoroutine(DamageCooldown(0.5f));
            }

            if(hp <= 0 )
            {   
                Destroy(gameObject);
                //queue game over screen
            }
        }
        if(collision.gameObject.tag == "Milk")
        {       
                if (hp == maxhp){
                    int n = 0;
                    bool wentOverFive= false;
                    while (n<4){

                        float score = 5*ScoreScript.multiplier;
                        ScoreScript.killCount += 1;
                        
                        if (wentOverFive){
                            score = 5*(ScoreScript.multiplier+0.2f);
                        }
                        ScoreScript.scoreValue +=score;
                        n++;
                        Debug.Log(n);
                        Debug.Log(ScoreScript.scoreValue);
                        if(ScoreScript.killCount%5 == 0 && ScoreScript.killCount !=0)
                        {
                            wentOverFive = true;
                        } 
                    } 
                    
                
                } 
                hp +=20;
                if (hp>maxhp){
                    hp =maxhp;
                }
                StartCoroutine(DamageCooldown(1.5f));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TrailEnemy")
        {
            shieldAllowed = false;
            if(!isTakingDamage)
            {
                Debug.Log("ahhh i took damage");
                dealDamage(damagetaken);
                isTakingDamage = true;
                StartCoroutine(DamageCooldown(0.5f));
            }

            if(hp <= 0 )
            {   
                Destroy(gameObject);
                //queue game over screen
            }
        }
        
    }


    IEnumerator DamageCooldown(float time)
    {
        yield return new WaitForSeconds(time);
        isTakingDamage = false;
    }
    IEnumerator shieldCooldown(float time)
    {
        yield return new WaitForSeconds(time);
    }
}