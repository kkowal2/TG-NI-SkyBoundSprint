using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    public TextMeshProUGUI bonusUI;
    public TextMeshProUGUI bonusTypeUI;
    public bool isBonusActive = false;
    private SpriteRenderer sr;
    private Animator an;
	public AudioSource eatSource;
	public AudioSource hitSource;

	private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bonusUI.enabled = false;
		eatSource = GameObject.Find("EatAudioSource").GetComponent<AudioSource>();
		hitSource = GameObject.Find("HitAudioSource").GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jump);
            an.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            an.enabled = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(isBonusActive == true)
            {

            }
            else
            {
				hitSource.Play();
				StartCoroutine(LoadSceneAfterDelay(0.2f));
			}
        }

        if (other.gameObject.CompareTag("Bonus"))
        {
            Debug.Log("BONUS!");
            //bonusUI.enabled = true;           
            StartCoroutine(ShowBonus());
            StartCoroutine(ShowBonusType());
			eatSource.Play();

		}
	}

	private IEnumerator LoadSceneAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(0);
	}

	private IEnumerator ShowBonus()
    {
        bonusUI.enabled = true;
        yield return new WaitForSeconds(2f);
        bonusUI.enabled = false;
    }

    private IEnumerator ShowBonusType()
    {
        sr.color = new Color(1f, 1f, 1f, 0.5f);
        isBonusActive = true;
        bonusTypeUI.text = "Immortality";
        bonusTypeUI.enabled = true;
        yield return new WaitForSeconds(5f);
        bonusTypeUI.enabled = false;
        isBonusActive = false;
        sr.color = Color.white;

    }
}
