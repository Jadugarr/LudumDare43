using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ShagMe : MonoBehaviour
{
    [SerializeField]
    private PlayerPlatformerController2D player;

    [SerializeField]
    private Transform playerShagPosition;

    private Animator shagPartnerAnimator;

    void Start()
    {
        this.shagPartnerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        // TODO check if player is close enough
        if (Input.GetButtonDown("Fire3"))
            attemptShagging();

    }


    public void attemptShagging()
    {
        shagPartnerAnimator.SetTrigger("startShag");
    }


    public void startShag()
    {
        player.transform.position = playerShagPosition.position;
        player.gameObject.SetActive(false);
        shagPartnerAnimator.SetBool("isSleepy", true);
    }


    public void finishShag()
    {
        player.gameObject.SetActive(true);
        LevelDefinitionBehaviour.IncreaseBunniesByValue(LevelDefinitionBehaviour.BunnyReplenishmentRate);
        if (shagPartnerAnimator.transform.localScale.x == -1)
        {
            // TODO player must face left
        }
        else
        {
            // TODO player must face right
        }
    }
}
