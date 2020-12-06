using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    private enum LayerName
    {
        IdleLayer = 0,
        WalkLayer = 1,
        AttackLayer = 2,
        SkillLayer = 3,
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeLayers();
    }

    // 애니메이션 변경
    private void ChangeLayers()
    {
        if (playerInput.IsMoving && !playerInput.isSkillAttack && !playerInput.isAttack)
        {
            ActivateLayer(LayerName.WalkLayer);
        }     
        else if (playerInput.isAttack)
        {
            ActivateLayer(LayerName.AttackLayer);
        }
       else if (playerInput.isSkillAttack)
       {
           ActivateLayer(LayerName.SkillLayer);
       }
        else
        {
            ActivateLayer(LayerName.IdleLayer);
        }
    }

    // 애니메이션 레이어 변경
    private void ActivateLayer(LayerName layerName)
    {
        // 모든 레이어의 무게값을 0 으로 지정
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        // 파라미터의 레이어의 무게값을 1로 지정
        animator.SetLayerWeight((int)layerName, 1);
    }
}
