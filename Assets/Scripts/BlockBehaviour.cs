using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    [SerializeField] AudioClip destoyedSound;
    [SerializeField] GameObject destroyedParticleFX;
    int maxHit;
    [SerializeField] int currentHit = 0;
    [SerializeField] Sprite[] hitSprites;
    LevelLogic level;
    GameStatus status;
    

    private void Start()
    {
        maxHit = hitSprites.Length + 1;
        level = FindObjectOfType<LevelLogic>();
        status = FindObjectOfType<GameStatus>();
        if( tag == "Breakable")
        {
            level.IncrementRemainingBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            currentHit++;
            if( currentHit >= maxHit)
            {
                BreakTheBlock();
            } else
            {
                LoadNextHitSprite();
            }
        }
    }

    private void LoadNextHitSprite()
    {
        int spriteIndex = currentHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void BreakTheBlock()
    {
        AudioSource.PlayClipAtPoint(destoyedSound, transform.position);
        level.DecrementRemainingBlock();
        status.AddPointToScore();
        Destroy(gameObject);
        PlayParticleFX();
    }

    private void PlayParticleFX()
    {
        var particle = Instantiate(destroyedParticleFX, transform.position, transform.rotation);
        //ParticleSystem ps = particle.GetComponent<ParticleSystem>();
        Destroy(particle, 1f);
    }
}
