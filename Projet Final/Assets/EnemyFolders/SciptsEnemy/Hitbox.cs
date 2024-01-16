using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private int _damage= 1;
    [SerializeField] private int _hitId = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HitMouvement();
    }
    
    /*
     * 0:coup du skelette
     * 1:tir du golem
     * 
     * But: Gérer les hitboxs des ennemies
     * 
     */
    private void HitMouvement()
    {
        switch (_hitId)
        {
            case 0:
                StartCoroutine(DestroyWait());
                break;
            case 1:
                transform.Translate(Vector3.left * Time.deltaTime * 4.0f);              
                break;
            case 2:
                StartCoroutine(DestroyWait());
                break;
        }
            
    }
    /*
     * But: Action lorsqu'une hitbox entre en collision
     * 
     * à ajouter: fonction joueur/castle qui reçoit un float qui correspond aux dégats du projectile
     * 
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {     
            //perdre vie joueur
            Destroy(gameObject);
            FindObjectOfType<Player>().Dommage();
        }
        if(other.tag == "Castle")
        {
            //perdre vie castle
            Destroy(gameObject);
            FindObjectOfType<Castle>().Dommage();
        }
    }
    IEnumerator DestroyWait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }
}
