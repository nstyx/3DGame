using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    private bool isCasting = false;
    private float currentCastTimer = 0f;
    private float spellcastCooldown = 1.4f;
    private float delay = 0.5f;
    [SerializeField] private Transform castPoint;
    [SerializeField] private GameObject spelltoCast;
    public TextMeshProUGUI spellAmmoText;
    public float spellSpeed = 8f;
    public Animator anim;
    public bool foundBook = false;
    public int spellAmmo = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3") &&(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)) // left shift
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
        // if firing and if not already firing and if foundbook and if not moving and if ammo available
        if(Input.GetButtonDown("Fire1") && !isCasting && foundBook &&(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) && spellAmmo > 0)
        {
            isCasting = true;
            currentCastTimer = 0;
            StartCoroutine(FireProjectileDelay());
            anim.SetBool("isShooting", true);
            spellAmmo -= 1;
            updateAmmo();
        }
        else
        {
            anim.SetBool("isShooting", false);
        }

        if(isCasting)
        {
            currentCastTimer += Time.deltaTime;
            if(currentCastTimer > spellcastCooldown) isCasting = false;
        }
    }
    
    public void updateAmmo()
    {
        spellAmmoText.text = "" + spellAmmo;
    }

    public void castSpell()
    {
        Instantiate(spelltoCast, castPoint.position, castPoint.rotation);
    }

    private IEnumerator FireProjectileDelay()
    {
        yield return new WaitForSeconds(delay);
        var ball = Instantiate(spelltoCast, castPoint.position, castPoint.rotation);
        ball.GetComponent<Rigidbody>().velocity = castPoint.forward * spellSpeed;
    }
}