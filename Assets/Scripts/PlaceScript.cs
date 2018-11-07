using UnityEngine;
using System.Collections;

public class PlaceScript : MonoBehaviour 
{
    public enum PlaceState
    {
        WALK, BLOCK, BASE1, BASE2, EMPTY
    }
    public PlaceState state;

	public int xPos, zPos, playerHand = 0, team = 0;
	public AttackerScript _attacker;
	private SpriteRenderer spriteRenderer;

    public bool isBreakable = false;
    public bool isSelected = false;
    public bool isBreaking = false;

    public Sprite walk, block, empty, base1, base2;
	public Sprite s_walk, s_block, s_base1, s_base2, s_empty;
    public Sprite b1_walk, b2_walk, b1_block, b2_block;

	// Use this for initialization
	void Start () {
		spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!isBreaking)
		    SetSprite();
        if (GetAttacker())
        {
            isBreakable = false;
        }
	}

	private void SetSprite()
	{
        switch (state)
        {
            case PlaceState.EMPTY:
                spriteRenderer.sprite = empty;
                break;
            case PlaceState.WALK:
                spriteRenderer.sprite = walk;
                break;
            case PlaceState.BLOCK:
                spriteRenderer.sprite = block;
                break;
            case PlaceState.BASE1:
                spriteRenderer.sprite = base1;
                break;
            case PlaceState.BASE2:
                spriteRenderer.sprite = base2;
                break;
            default:
                Debug.LogError("Sprite cannot be set!");
                break;
        }

        if (isSelected)
        {
            if (spriteRenderer.sprite == empty)
                spriteRenderer.sprite = s_empty;
            if (spriteRenderer.sprite == walk)
                spriteRenderer.sprite = s_walk;
            if (spriteRenderer.sprite == block)
                spriteRenderer.sprite = s_block;
            if (spriteRenderer.sprite == base1)
                spriteRenderer.sprite = s_base1;
            if (spriteRenderer.sprite == base2)
                spriteRenderer.sprite = s_base2;
        }
	}

    public void SetState(PlaceState inputState)
    {
        state = inputState;
    }

    public void SetState(string placestate)
    {
        switch (placestate)
        {
            case "WALK":
                state = PlaceState.WALK;
                break;
            case "BLOCK":
                state = PlaceState.BLOCK;
                break;
            case "EMPTY":
                state = PlaceState.EMPTY;
                break;
            case "BASE1":
                state = PlaceState.BASE1;
                break;
            case "BASE2":
                state = PlaceState.BASE2;
                break;
            default:
                Debug.LogErrorFormat("{0} cannot be set as a PlaceState!",placestate);
                break;
        }
    }

    public bool GetState(string placestate)
    {
        switch (placestate)
        {
            case "WALK":
                if(state == PlaceState.WALK)
                    return true;
                break;
            case "BLOCK":
                if (state == PlaceState.BLOCK)
                    return true;
                break;
            case "EMPTY":
                if (state == PlaceState.EMPTY)
                    return true;
                break;
            case "BASE1":
                if (state == PlaceState.BASE1)
                    return true;
                break;
            case "BASE2":
                if (state == PlaceState.BASE2)
                    return true;
                break;
            default:
                Debug.LogErrorFormat("{0} isn't a PlaceState!", placestate);
                break;
        }
        return false;
    }

    public PlaceState GetState()
    {
        return state;
    }

    public void ToggleSelectable()
    {
        if (!isSelected)
            isSelected = true;
        else
            isSelected = false;
    }

	public bool SetAttacker(AttackerScript attacker)
	{
        if(attacker == null)
        {
            _attacker = null;
            return true;
        }

		if(_attacker)
		{
			Debug.LogError("Cannot set attacker.");
			return false;
		}

		_attacker = attacker;
		return true;
	}

	public AttackerScript GetAttacker()
	{
		return _attacker;
	}

    public int BreakAnimation(float timer)
    {
        int blockType = 0;
        if(timer > 0f)
        {
            isBreaking = true;
            if (spriteRenderer.sprite == walk)
                spriteRenderer.sprite = b1_walk;
            if (spriteRenderer.sprite == block)
                spriteRenderer.sprite = b1_block;
        }
        if (timer > 1f)
        {
            if (spriteRenderer.sprite == b1_walk)
                spriteRenderer.sprite = b2_walk;


            if (spriteRenderer.sprite == b1_block)
                spriteRenderer.sprite = b2_block;

        }
        if(timer > 2f)
        {
            if(spriteRenderer.sprite == b2_walk)
                blockType = 1;
            if (spriteRenderer.sprite == b2_block)
                blockType = 2;
            //state = PlaceState.EMPTY;
        }
        return blockType;
    }
}
