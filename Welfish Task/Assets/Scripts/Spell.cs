using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] Transform spellPoint;
    [SerializeField] GameObject speelAPrefab;
    [SerializeField] AudioClip[] spellSfxs;
    bool canFire = true;
    float fireDelay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.IsAttackPressed && !playerController.IsAttacking && canFire) {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        canFire = false;
        Instantiate(speelAPrefab, spellPoint.position, transform.rotation);
        AudioSource.PlayClipAtPoint(spellSfxs[Random.Range(0,spellSfxs.Length)], transform.position, 1.3f);
        playerController.IsAttacking = true;
        yield return new WaitForSeconds(fireDelay);
        playerController.IsAttacking = false;
        canFire = true;
    }

}
