using UnityEngine;

public class AnimeTrigger : MonoBehaviour
{
    private Animator animator;
    private bool isDead = false;

    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    
    public void TakeDamage()
    {
        if (isDead) Death(); 
        animator.SetTrigger("Hurt");
        animator.SetTrigger("SnakeAttack");
    }
 
    
    public void Death()
    {
        isDead = true;
        animator.SetTrigger("Death");
    }
}
