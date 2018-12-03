using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScriptGO : MonoBehaviour {

public float speed;
Rigidbody2D rb2d;
public bool MoveAir = true;
public bool OnWall = false;
public bool facingRight;
public GameObject Player;
public float dashSpeed = 20;
private float Hp = 3;
public bool alive = true;
public float immunityTime = 1;
public bool immunity = false;
public bool immuTimer;
public static bool dash;
private float dashCooldown;
private float dashTime;
float speedDouble;
public GameObject ResetPosition;
public AudioSource AudioSource;
public AudioSource Musica;
public AudioSource DeathPlayer;
Animator anim;
Vector3 originalPosition;
Collider2D col;

// RUBAN
    protected AnimatorOverrideController animatorOverrideController;
    protected int ruban_index;
   // protected AnimationClipOverrides clipOverrides;

//  /RUBAN

    [System.Serializable]
    private class AnimationClipOverride
    {
        public string clipNamed;
        public AnimationClip overrideWith;
    }
	void Start () {
        col = GetComponent<Collider2D>();
        Vector3 originalPosition = ResetPosition.transform.position;
		rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        dash = false;
        speedDouble = 1.5f;
        dashCooldown = 0.5f;
        // RUBAN 
         ruban_index = 0;

       animatorOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
       anim.runtimeAnimatorController = animatorOverrideController;
       // clipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
      //  animatorOverrideController.GetOverrides(clipOverrides);
	}
        [SerializeField] AnimationClipOverride[] Ruban2;
        [SerializeField] AnimationClipOverride[] Ruban3;
    public void Init (Animator animator)
    {
       // AnimatorOverrideController overrideController = new AnimatorOverrideController();
        // overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
 
        foreach(AnimationClipOverride Ruban2 in Ruban2)
        {
            if (Hp == 2)
            {
                animatorOverrideController[Ruban2.clipNamed] = Ruban2.overrideWith;
            }
            foreach (AnimationClipOverride Ruban3 in Ruban3)
            {
            if (Hp == 1)
            {
                animatorOverrideController[Ruban3.clipNamed] = Ruban3.overrideWith;
            } 
            }
        }
        animator.runtimeAnimatorController = animatorOverrideController;
    }
// RUBAN
    void MortPlayer()
    {
        Destroy(Player);
    }
    void SoundDeath()
    {
        DeathPlayer.Play();
    }
	void Update () {
        Init(anim); // Animation Ovverride pour change les animations avec ruban
		float Move = Input.GetAxisRaw("Horizontal");
        float MoveV = Input.GetAxisRaw("Vertical");
        Movement(Move, MoveV);
		Animation();
        // HP SYSTEM
        if (Hp == 0)
        {
            alive = false;
        }
        if (alive == false)
        {
        Musica.Stop();
        speed = 0;
        speedDouble = 0;
        dash = false;
        anim.SetBool("Death", true);
        }
        
        if (Input.GetButtonDown("immu") && !immuTimer )
        {
            immuTimer = true;
            SetImmunity();
            Invoke("resetTimerImmunity", 5f);
        }
        // FixedUpdate() a la base
        Dash();

        // Change color immunity
        if (immunity == true)
        {
            Player.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1);
        }
        else
        {
            Player.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
        }
        //
	}

	 public void Movement(float horizontalInput, float verticalInput)
    {
        // JOUEUR HORIZONTAL : S & F et spécial :  D -- JOUEUR VERTICAL : K & O et spécial : M ; JOUEUR SOLO : FLECHE DIRECTIONNELLE.
        // Ne pas s'accrocher au mur
        if (!MoveAir && OnWall == true)
            return;
        //
        Vector2 moveVel = rb2d.velocity;
        moveVel.x = horizontalInput * speed;
        moveVel.y = verticalInput * speed * speedDouble;
        rb2d.velocity = moveVel;
    }

	public void Animation()
	{
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            if (Input.GetAxisRaw("Horizontal") < -0.5f && facingRight && speed > 0)
            {
              Flip();
               facingRight = false;
               dash = false;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0.5f && !facingRight && speed > 0)
            {
               Flip();
                facingRight = true;
               dash = false;
            }
	}
    float Move = Input.GetAxisRaw("Horizontal");
        if (Move != 0 && dash == false)
        {
            anim.SetBool("RunDroite", true);
           // anim.SetBool("DashDroite", false);
        }
        else
        {
            anim.SetBool("RunDroite", false);
           // anim.SetBool("DashDroite", false);
        }
    float MoveV = Input.GetAxisRaw("Vertical");
    if (MoveV != 0 && MoveV >= 0.5f && dash == false)
    {
        anim.SetBool("RunHaut", true);
        anim.SetBool("RunBas", false);
            anim.SetBool("DashBas", false);
            anim.SetBool("DashHaut", false);
            anim.SetBool("DashDroite", false);
    }
    else if (MoveV != 0 && MoveV <= -0.5f && dash == false)
    {
        anim.SetBool("RunHaut", false);
        anim.SetBool("RunBas", true);
        anim.SetBool("DashBas", false);
        anim.SetBool("DashHaut", false);
        anim.SetBool("DashDroite", false);
    }
   else
    {
        anim.SetBool("RunHaut", false);
        anim.SetBool("RunBas", false);
    }
    if (dash == true)
    {
        anim.SetBool("RunHaut", false);
        anim.SetBool("RunBas", false);
        anim.SetBool("RunDroite", false);
    }
	}
	 void Flip()
    {
       facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *=-1;
        transform.localScale = theScale;
    }

    IEnumerator DashFalseCount()
    {
        yield return new WaitForSeconds(0.45f);
        dash = false;
    }

    IEnumerator DashCollider()
    {
        col.enabled = !col.enabled;
        yield return new WaitForSeconds(0.15f);
        col.enabled = !col.enabled;
    }
    
	// COLLISION WITH EVENT !!!
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ResetPlayer") // reset position if en dehors de la carte
        {
            Player.transform.position = originalPosition;
        }
        if (collider.gameObject.tag == "EVENTDAMAGE"  && immunity == false)
        {
            Hp -= 1;
            Debug.Log("-1 HP");
           StartCoroutine(GetHit());
           Flip();
           AudioSource.Play();
        }
       if(collider.gameObject.tag == "Poings" && immunity == false)
        {
            Hp -= 1;
            Debug.Log("-1 HP");
            StartCoroutine(GetHit());
            Flip();
            AudioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // COLLISION POINT DE VIE 
    {
        if (collision.gameObject.tag == "Wall")
        {
            OnWall = true;
        }
        if (collision.gameObject.tag == "EVENTDAMAGE" && immunity == false)
        {
            Hp -= 1;
            Debug.Log("-1 HP");
            StartCoroutine(GetHit());
            Flip();
            AudioSource.Play();
        }
        if (collision.gameObject.tag == "Massive" && immunity == false)
        {
            Hp -= 1;
            Debug.Log("-1 HP");
            StartCoroutine(GetHit());
            Flip();
        }
        /*  
        if (collision.gameObject.tag == "Triangle" && immunity == false)
        {
            Hp -= 1;
            Debug.Log("-1 HP");
            StartCoroutine(GetHit());
            Flip();
        }
               if (collision.gameObject.tag == "Balls" && immunity == false)
        {
            Hp -= 1;
            Debug.Log("-1 HP");
            StartCoroutine(GetHit());
            Flip();
        } */
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            OnWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            OnWall = false;
        }
    }

// DASH ANIMATION ET VELOCITE 
    void Dash()
    {
        dashTime += Time.deltaTime;
        if (dashTime < dashCooldown)
        {
            return;
        }
        if (Input.GetButtonDown("Dash"))
        {
            dashTime = 0;
            dash = true;
            StartCoroutine(DashCollider());
            rb2d.AddForce(rb2d.velocity * dashSpeed, ForceMode2D.Impulse);
            StartCoroutine(DashFalseCount());
        }
        float MoveV = Input.GetAxisRaw("Vertical");
        float Move = Input.GetAxisRaw("Horizontal");
        if (Move != 0 && dash == true)
        {
anim.SetBool("DashDroite", true);
anim.SetBool("RunDroite", false);
        }
        if (MoveV != 0 && MoveV >= 0.5f && dash == true)
        {
            anim.SetBool("DashHaut", true);
            anim.SetBool("RunHaut", false);
        }
        else if (MoveV != 0 && MoveV <= -0.5f && dash == true)
        {
            anim.SetBool("DashBas", true);
            anim.SetBool("RunHaut", false);
        }
        if (dash == false)
        {
            anim.SetBool("DashBas", false);
            anim.SetBool("DashHaut", false);
            anim.SetBool("DashDroite", false);
        }
        
    }

    void DashFalse()
    {
        dash = false;
    }

// IMMUNITY 
   public void SetImmunity()
   {
       immunity = true;
       CancelInvoke("SetDamage");
       Invoke("SetDamage", immunityTime);
   }
   
   void SetDamage()
    {
        immunity = false;
    }

    private void resetTimerImmunity()
    {
        immuTimer = false;
    }

    IEnumerator GetHit()
    {
        anim.SetBool("GetHit", true);
        speed = 0;
        speedDouble = 0;
        CancelInvoke("SetDamage");
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("GetHit", false);
        speed = 3;
        speedDouble = 1.5f;
        Invoke("SetDamage", 0);
    }

}// <== End;


// <==== RUBAN1 RUBAN2 RUBAN3 ====>
public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
{
    public AnimationClipOverrides(int capacity) : base(capacity) {}

    public AnimationClip this[string name]
    {
        get { return this.Find(x => x.Key.name.Equals(name)).Value; }
        set
        {
            int index = this.FindIndex(x => x.Key.name.Equals(name));
            if (index != -1)
                this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
        }
    }
}

