using UnityEngine;

public class MonsterStateMachine
{
    MonsterState currentState;
    Monster currentMonster;
    private Vector3 move;

    Vector3Int lastPosition = Vector3Int.zero;
    Vector3Int startPosition = Vector3Int.zero;

    public void SetMonster(Monster monster)
    {
        currentMonster = monster;
    }
    public void ChangeState(MonsterState state)
    {
        if (state == currentState)
        {
            return;
        }
        move.x = 0;
        this.currentState = state;
    }
    public void UpdateState()
    {
        currentMonster.isGround = currentMonster.movementColliders.GroundCheck(currentMonster.transform, currentMonster.moveLayerMask);
        if (!currentMonster.isGround)
        {
            move.y -= currentMonster.gravity * Time.deltaTime;
        }
        else
        {
            move.y = 0;
        }
        switch (currentState)
        {
            case MonsterState.wating:
                break;
            case MonsterState.searching:
                startPosition = Map.instance.tilemap.layoutGrid.WorldToCell(currentMonster.transform.position);
                if (currentMonster.isGround)
                { 
                    if(move.x == 0) move.x = 1;

                    if (currentMonster.movementColliders.CheckSides(move, currentMonster.transform, currentMonster.moveLayerMask)) // der character soll auch nirgendwo hin, wo er runterfallen könnte. Der Check ist aber noch buggy
                    {
                        move.x *= -1;
                    }
                }

                break;
            case MonsterState.following:
                if (currentMonster.currentdistance > currentMonster.distanceToPlayer)
                {
                    move.x = Mathf.Clamp(playerData.instance.GetPositionData().x - currentMonster.transform.position.x, -1F, 1F);
                    if (currentMonster.movementColliders.CheckSides(move, currentMonster.transform, currentMonster.moveLayerMask))
                    {
                        move.x = 0;
                        if (currentMonster.isGround)
                        {
                            lastPosition = Map.instance.tilemap.layoutGrid.WorldToCell(currentMonster.transform.position);
                            lastPosition.x = move.x > 0 ? lastPosition.x++ : lastPosition.x--;
                            lastPosition.y++;
                            move.y = 3F;
                            while ((int)Map.instance.levelGenManager.GetBaseMap().GetValue(lastPosition.x,lastPosition.y) != 0)
                            {
                                move.y = move.y + 1F;
                                lastPosition.y++;
                            }
                            if(move.y > 6F) move.y = 6;
                        }
                    }
                }
                else
                {
                    move.x = 0;
                }

                move.z = 0;
                break;
            case MonsterState.attacking:
                break;
            default:
                break;

        }
        currentMonster.transform.Translate(move * currentMonster.walkSpeed * Time.deltaTime);
    }
}
