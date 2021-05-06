using System.Collections.Generic;
using UnityEngine;

public static class QueueManager
{
    public static GameObject DeQueueNextWall()
    {
        return GridSettings.Instance.wallQueue.Dequeue();
    }

    public static GameObject DeQueueNextPawn()
    {
        return GridSettings.Instance.queuedShapes.Dequeue();
    }

    // this will generate a pair tetrimino + wall and put it in queues
    public static void EnqueueNewPair()
    {
        /**
        *** Pick a random shape from the vector of prefabs
        ///TODO this vector may become a pool from where to pick the active tetrimino 
            instead of instanciating the same thing over and over again
        **/
        GameObject shape = GridSettings.Instance.shapes[Random.Range(0, GridSettings.Instance.shapes.Length)];
        GridSettings.Instance.wallShape = GameInstancesManager.InstanciateWallBrick(GridSettings.Instance.obstacleObject, shape, Vector2.zero);

        System.Action rotateRandom = () =>
        {
            /**
            *** Pick a random number between 0 and 3
            *** Use that number to set rotation of tetrimino at 0/90/180/270 °
            */
            int rotation = Random.Range(0, 3);
            for (int i = 0; i < rotation; i++)
            {
                TetriminosController.RotateWallPlaceholder();
            }
        };

        System.Action moveRandom = () =>
        {   /**
            *** Pick a random number between the margins of the grid
            *** Use that number to try to move to the choosen column
            */
            int xPosition = Random.Range(-GridSettings.Instance.width / 2, GridSettings.Instance.width / 2);
            for (int i = 0; i < Mathf.Abs(xPosition); i++)
            {
                TetriminosController.MoveWallPlaceholder(Vector2.right * Mathf.Sign(xPosition));
            }

            /**
            *** Pick a random number between the margins of the grid
            *** Use that number to try to move to the choosen row
            */
            if (!GamePlaySettings.onlyHorizontal)
            {
                int yPosition = Random.Range(0, GridSettings.Instance.height);
                for (int i = 0; i < Mathf.Abs(yPosition); i++)
                {
                    TetriminosController.MoveWallPlaceholder(Vector2.up * Mathf.Sign(yPosition));
                }
            }
        };

        if (Random.Range(0.0f, 1.0f) >= 0.5f)
        {
            rotateRandom();
            moveRandom();
        }
        else
        {
            moveRandom();
            rotateRandom();
        }

        /**
        *** save positions in a queue for faster check
        */
        Queue<Vector2> positionQueue = new Queue<Vector2>();
        for (int i = 0; i < 4; i++)
        {
            GridSettings.Instance.obstacleGrid.GetGridPosition(GridSettings.Instance.wallShape.transform.GetChild(i).transform.position + Vector3.one * 0.1f, out int x, out int y);
            positionQueue.Enqueue(new Vector2(x, y));
        }
        /// TODO this may be unnecessary when the tetriminos are pooled and not instanciated one at time
        MonoBehaviour.Destroy(GridSettings.Instance.wallShape);

        /**
        *** create an empty container for the wall
        *** set it as inactive for now
        *** and produce a wall brick by brick 
        *** using trigger bricks to make the hole
        */
        GameObject container = GameInstancesManager.NewGameObject("wallContainer");
        container.SetActive(false);
        GameObject toSpawn;
        for (int i = 0; i < GridSettings.Instance.width; i++)
        {
            for (int j = 0; j < GridSettings.Instance.height; j++)
            {
                Vector2 pos = GridSettings.Instance.obstacleGrid.GetWorldPosition(i, j);
                if (positionQueue.Contains(new Vector2(i, j)))
                {
                    toSpawn = GridSettings.Instance.hollowBrick;
                }
                else
                {
                    toSpawn = GridSettings.Instance.blockingBrick;
                }
                GameInstancesManager.InstanciateWallBrick(container, toSpawn, pos);
            }
        }

        //setup wall container
        Rigidbody rb = container.AddComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        container.AddComponent<WallBehaviour>();

        /// Enqueue the wall container and the shape for the next call of game manager
        GridSettings.Instance.wallQueue.Enqueue(container);

        GridSettings.Instance.queuedShapes.Enqueue(shape);
    }



}
