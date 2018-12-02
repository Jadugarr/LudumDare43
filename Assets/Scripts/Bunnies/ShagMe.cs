using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Common;
using UnityEngine;

public class ShagMe : MonoBehaviour
{
    [SerializeField]
    private Transform playerShagPosition;

    [SerializeField]
    private int babyCount = -1;

    private PlayerPlatformerController2D player;
    private Animator shagPartnerAnimator;
    private bool isShagging = false;

    void Start()
    {
        this.shagPartnerAnimator = GetComponent<Animator>();
    }


    protected void OnTriggerEnter2D(Collider2D col)
    {
        player = col.GetComponentInParent<PlayerPlatformerController2D>();
        if (player && !shagPartnerAnimator.GetBool("isSleepy"))
        {
            TurnToPlayer();
            attemptShagging();
        }
    }


    protected void OnTriggerExit2D(Collider2D col)
    {
        if (!isShagging && col.GetComponentInParent<PlayerPlatformerController2D>() == player)
            player = null;
    }


    public void attemptShagging()
    {
        shagPartnerAnimator.SetTrigger("startShag");
    }

    private void TurnToPlayer()
    {
        if (player)
        {
            Vector3 partnerScale = shagPartnerAnimator.transform.parent.localScale;
            partnerScale.x = (player.transform.position.x < shagPartnerAnimator.transform.position.x) ? -1 : 1;
            shagPartnerAnimator.transform.parent.localScale = partnerScale;
        }
    }


    public void startShag()
    {
        isShagging = true;
        if (player.isFacingRight != (player.transform.position.x < shagPartnerAnimator.transform.position.x))
            player.Flip();

        TurnToPlayer();
        shagPartnerAnimator.SetBool("isSleepy", true);
        SetPlayerEnabled(false);
    }


    public void finishShag()
    {
        SetPlayerEnabled(true);
        LevelDefinitionBehaviour.IncreaseBunniesByValue(babyCount == -1 ? LevelDefinitionBehaviour.BunnyReplenishmentRate : babyCount);
        player.Flip();
    }


    private void SetPlayerEnabled(bool state)
    {
        StaticConstants.AcceptPlayerInput = state;
        player.transform.position = playerShagPosition.position;

        Color invisColor = Color.white;
        invisColor.a = state ? 1f : 0f;
        player.GetComponentInChildren<SpriteRenderer>().color = invisColor;

    }

    public void Snooze()
    {
        transform.parent.GetComponentInChildren<ParticleSystem>().Play();
    }
}
