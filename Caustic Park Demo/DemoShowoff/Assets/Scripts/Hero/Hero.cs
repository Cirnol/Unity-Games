using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Hero : MonoBehaviour
{
    public float HP;
    public float maxHP;

    public HUD hud;

    public float deathDelayTimer;

    private float timer = 0.0f;
    private float maxTime = 0.3f;

    public bool godMode;

    public List<AudioClip> DamageSounds;

    public AudioClip EnemySpottedSound;
    public AudioClip DeathSound;
    private bool playingEnemySpottedSound = false;
    public AudioSource damageAudioSource;
    public AudioSource enemySpottedAudioSource;
    public AudioSource deathAudioSource;
    public float enemySpottedAttack;
    public float enemySpottedDecay;
    private float enemySpottedTime0;
    private bool enemySpottedSoundStopped;
    public FOV fov;
    public BeamFOVHandler beamHandler;
    private bool dead;

    private string cheatcode = "";
    public void DealDamage(float damage)
    {
        HP -= damage;
        hud.playerHit(damage);
        if (DamageSounds.Count > 0 && !dead) {
            int damageSoundIndex = Random.Range(0, DamageSounds.Count);
            damageAudioSource.PlayOneShot(DamageSounds[damageSoundIndex]);
            playingEnemySpottedSound = false;
        }
    }
    private void Update()
    {
        if (fov.EnemyVisible() && !dead)
        {
            if (!playingEnemySpottedSound)
            {
                if (enemySpottedSoundStopped)
                {
                    enemySpottedAudioSource.Play();
                    enemySpottedSoundStopped = false;
                }
                enemySpottedAudioSource.volume = 0;
                enemySpottedTime0 = Time.time;
                playingEnemySpottedSound = true;
            }
            enemySpottedAudioSource.volume = Mathf.Min(1.0f, (Time.time - enemySpottedTime0) / enemySpottedAttack);
        }
        else if (playingEnemySpottedSound)
        {
            playingEnemySpottedSound = false;
            enemySpottedTime0 = Time.time;
        }
        else
        {
            enemySpottedAudioSource.volume = Mathf.Max(0.0f, 1.0f - ((Time.time - enemySpottedTime0) / enemySpottedDecay));
            if (enemySpottedAudioSource.volume == 0.0f)
            {
                enemySpottedAudioSource.Stop();
                enemySpottedSoundStopped = true;
            }
        }
        foreach (char c in Input.inputString)
        {
            if (c == 'n')
            {
                if(cheatcode == "kelvi")
                {
                    godMode = !godMode;
                }
                cheatcode = "";
                
            }
            else
            {
                cheatcode += c;
            }
        }
        if (Input.inputString == "kelvin")
        {
            Debug.Log("godMode");
            godMode = !godMode;

        }

        if (!godMode && HP <= 0)
        {
            enemySpottedAudioSource.volume = 0;
            enemySpottedAudioSource.Stop();
            if (!dead)
            {
                GameObject musicObject = GameObject.FindGameObjectWithTag("music");
                if (musicObject != null)
                {
                    musicObject.GetComponent<AudioSource>().Stop();
                }
                deathAudioSource.PlayOneShot(DeathSound);
                deathDelayTimer = DeathSound.length;
                dead = true;
            }
            hud.die();
            deathDelayTimer -= Time.deltaTime;
            if (deathDelayTimer <= 0)
            {
                enemySpottedAudioSource.volume = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
