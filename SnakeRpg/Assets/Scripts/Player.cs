using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float gridSize;
    [SerializeField] private float moveSpeed = 1.5f;//Grid per seconds
    private MoveState moveState;
    private Direction direction;
    private IReadOnlyList<(KeyCode, Direction)> keyDirecTionMap = new List<(KeyCode, Direction)>()
    {
        (KeyCode.UpArrow, Direction.Up),
        (KeyCode.DownArrow, Direction.Down),
        (KeyCode.LeftArrow, Direction.Left),
        (KeyCode.RightArrow, Direction.Right),
    };

    public enum MoveState
    {
        None,
        MoveSingle,
    }

    public enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right,
    }

    private void Awake() => gridSize = spriteRenderer.bounds.size.x / spriteRenderer.sprite.pixelsPerUnit;

    private void Update()
    {
        if (moveState == MoveState.MoveSingle)
        {
            return;
        }

        if (TryGetDirectionFromInput(out direction))
        {
            StartCoroutine(MoveSingle(direction));
        }
    }

    private bool TryGetDirectionFromInput(out Direction direction)
    {
        direction = Direction.None;
        foreach (var (key, dir) in keyDirecTionMap)
        {
            if (Input.GetKey(key))
            {
                direction = dir;
                return true;
            }
        }

        return false;
    }

    private IEnumerator MoveSingle(Direction direction)
    {
        moveState = MoveState.MoveSingle;
        var time = 0f;
        var totalTime = 1 / moveSpeed;
        var delta = DirectionToDelta(direction) * gridSize;
        while (time < totalTime)
        {
            yield return null;
            time += Time.deltaTime;
            gameObject.transform.position += delta;
        }

        moveState = MoveState.None;
    }

    private IEnumerator MoveSingle2(Direction direction)
    {
        moveState = MoveState.MoveSingle;
        var time = 0f;
        var totalTime = 1 / moveSpeed;
        var src = gameObject.transform.position;
        var dest = gameObject.transform.position + DirectionToDelta(direction) * gridSize;
        while (time < totalTime)
        {
            yield return null;
            time += Time.deltaTime;
            gameObject.transform.position += Vector3.Lerp(src, dest, time / totalTime);
        }

        moveState = MoveState.None;
    }

    private Vector3 DirectionToDelta(Direction direction) => direction switch
    {
        Direction.Up => Vector2.up,
        Direction.Down => Vector2.down,
        Direction.Left => Vector2.left,
        Direction.Right => Vector2.right,
        _ => Vector2.zero,
    };
}
