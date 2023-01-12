using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratoCell
{
    private int X;
    private int Y;

    [SerializeField] private bool wallLeft = true;
    [SerializeField] private bool wallRight = true;
    private bool visited = false;
    private int distansFromStart;

    public int X1 { get => X; set => X = value; }
    public int Y1 { get => Y; set => Y = value; }
    public bool WallLeft { get => wallLeft; set => wallLeft = value; }
    public bool WallRight { get => wallRight; set => wallRight = value; }
    public bool Visited { get => visited; set => visited = value; }
    public int DistansFromStart { get => distansFromStart; set => distansFromStart = value; }
}
public class MazeGenerator 
{
    [SerializeField] private int Widht = 22;
    [SerializeField] private int Height = 15;

    public int Widht1 { get => Widht; set => Widht = value; }
    public int Height1 { get => Height; set => Height = value; }

    public MazeGeneratoCell[,] GenerateMaze()
    {
        MazeGeneratoCell[,] maze = new MazeGeneratoCell[Widht1, Height1];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratoCell { X1 = x, Y1 = y };
            }
        }
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            maze[x, Height - 1].WallRight = false;
        }
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            maze[Widht - 1, y].WallRight = false;
        }
            RemoveWall(maze);

        PlaceMazeExit(maze);
        return maze;
    }

    private void PlaceMazeExit(MazeGeneratoCell[,] maze)
    {
        MazeGeneratoCell furthest = maze[0,0];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, Height - 2].DistansFromStart > furthest.DistansFromStart) furthest = maze[x, Height - 2];
            if (maze[x,0].DistansFromStart > furthest.DistansFromStart) furthest = maze[x, 0];
        }
        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[Widht - 2,y].DistansFromStart > furthest.DistansFromStart) furthest = maze[ Widht - 2,y];
            if (maze[0,y].DistansFromStart > furthest.DistansFromStart) furthest = maze[0, y];
        }
    }

    private void RemoveWall(MazeGeneratoCell[,] maze)
    {
        MazeGeneratoCell current = maze[0, 0];
        current.Visited = true;
        current.DistansFromStart = 0;
        Stack<MazeGeneratoCell> stack = new Stack<MazeGeneratoCell>();
        do
        {
            List<MazeGeneratoCell> invisitedNeighbours = new List<MazeGeneratoCell>();

            int x = current.X1;
            int y = current.Y1;
            if (x > 0 && !maze[x - 1, y].Visited) invisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y -1].Visited) invisitedNeighbours.Add(maze[x, y-1]);
            if(x < Widht -2 && !maze[x+1,y].Visited) invisitedNeighbours.Add(maze[x + 1, y]);
            if (x < Height - 2 && !maze[x, y +1].Visited) invisitedNeighbours.Add(maze[x, y + 1]);
            if(invisitedNeighbours.Count >0)
            {
                MazeGeneratoCell choes = invisitedNeighbours[Random.Range(0, invisitedNeighbours.Count)];
                RemuveWall(current, choes);
                choes.Visited = true;
                stack.Push(choes);
                current = choes;
                choes.DistansFromStart = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }

    private void RemuveWall(MazeGeneratoCell a, MazeGeneratoCell b)
    {
       if(a.X1 == b.X1)
        {
            if (a.Y1 > b.Y1) a.WallRight = false;
            else b.WallRight = false;
        }
    }
}
