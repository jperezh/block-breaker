using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public AudioClip crack;
    public Sprite[] hitSpites;
    public static int breakableCount = 0;
    public GameObject effect;

    private LevelManager levelManager;
    private int timesHit = 0;
    private AudioSource m_audioSource;

    private void Start() {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        m_audioSource = gameObject.GetComponent<AudioSource>();
    }

    /**
     * Handles the collision of the brick
     */
    private void OnCollisionEnter2D(Collision2D collision) {
        if (m_audioSource) {
            m_audioSource.Play();
        } else {
            AudioSource.PlayClipAtPoint(crack, transform.position);
        }
        
        if (gameObject.tag != "Breakable") {
            return;
        }
        int maxHitpoint = hitSpites.Length + 1;

        timesHit++;

        if (timesHit >= maxHitpoint) {
            // If the audiosoruce is set then destroy the object AFTER the audio clip has played
            if (m_audioSource) {
                gameObject.GetComponent<Renderer>().enabled = false;
                Destroy(gameObject, m_audioSource.clip.length);
            } else {
                Destroy(gameObject);
            }
            // Play the effect
            Brick.breakableCount--;
            if (Brick.breakableCount <= 0) {
                levelManager.LoadNextLevel();
            }
        } else {
            LoadSprites();
        }
    }

    /**
     * Function to load the appropiate sprite depending on the times the brick is hit
     */
    private void LoadSprites() {
        int spriteIndex = timesHit - 1;
        if (hitSpites[spriteIndex]) {
            gameObject.GetComponent<SpriteRenderer>().sprite = hitSpites[spriteIndex];
        } else {
            Debug.LogError("Could not load sprite for the index " + spriteIndex);
        }
    }
}
