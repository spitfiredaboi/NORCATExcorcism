using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class boss : MonoBehaviour
{
    public CinemachineTargetGroup cam;
    public GameObject leftCamFix;
    public GameObject rightCamFix;
    public GameObject[] hearts;
    public float health = 7;
    public bool isTransformed = false;
    public bool isTransforming = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hearts[0] = GameObject.Find("BossHeart0");
        hearts[1] = GameObject.Find("BossHeart1");
        hearts[2] = GameObject.Find("BossHeart2");
        hearts[3] = GameObject.Find("BossHeart3");
        hearts[4] = GameObject.Find("BossHeart4");
        hearts[5] = GameObject.Find("BossHeart5");
        hearts[6] = GameObject.Find("BossHeart6");
        hearts[7] = GameObject.Find("GoldHeart0");
        hearts[8] = GameObject.Find("GoldHeart1");
        hearts[9] = GameObject.Find("GoldHeart2");
        hearts[10] = GameObject.Find("GoldHeart3");
        hearts[11] = GameObject.Find("GoldHeart4");
        hearts[12] = GameObject.Find("GoldHeart5");
        hearts[13] = GameObject.Find("GoldHeart6");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isTransforming", isTransforming);
        if (health == 14)
        {
            SetAllActive();
        }
        else if (health < 14)
        {
            hearts[13].SetActive(false);
            if (health < 13)
            {
                hearts[12].SetActive(false);
                if (health < 12)
                {
                    hearts[11].SetActive(false);
                    if (health < 11)
                    {
                        hearts[10].SetActive(false);
                        if (health < 10)
                        {
                            hearts[9].SetActive(false);
                            if (health < 9)
                            {
                                hearts[8].SetActive(false);
                                if (health < 8)
                                {
                                    hearts[7].SetActive(false);
                                    if (health < 7)
                                    {
                                        hearts[6].SetActive(false);
                                        if (health < 6)
                                        {
                                            hearts[5].SetActive(false);
                                            if (health < 5)
                                            {
                                                hearts[4].SetActive(false);
                                                if (health < 4)
                                                {
                                                    hearts[3].SetActive(false);
                                                    if (health < 3)
                                                    {
                                                        hearts[2].SetActive(false);
                                                        if (health < 2)
                                                        {
                                                            hearts[1].SetActive(false);
                                                            if (health < 1)
                                                            {
                                                                hearts[0].SetActive(false);
                                                                if (isTransformed == false)
                                                                {
                                                                    StartCoroutine(Transform());
                                                                }
                                                                else
                                                                {
                                                                    StartCoroutine(Death());
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    IEnumerator Transform()
    {
        isTransformed = true;
        isTransforming = true;
        yield return new WaitForSeconds(1.5f);
        isTransforming = false;
    }

    public void SetAllActive()
    {
        foreach(GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }    

}
