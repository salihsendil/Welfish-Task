using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] Transform spellPoint;
    [SerializeField] GameObject speelAPrefab;
    [SerializeField] AudioClip[] spellSfxs;
    float fireDelay = 2f;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.IsAttackPressed && !playerController.IsAttacking) {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        Instantiate(speelAPrefab, spellPoint.position, transform.rotation);
        AudioSource.PlayClipAtPoint(spellSfxs[Random.Range(0,spellSfxs.Length)], transform.position, 1.3f);
        playerController.IsAttacking = true;
        yield return new WaitForSeconds(fireDelay);
        playerController.IsAttacking = false;
    }

}
