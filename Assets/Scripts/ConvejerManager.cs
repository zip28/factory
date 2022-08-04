using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public struct Belt
{
    public Vector2Int Position;
    private int direct;
    public Vector2Int Direction
    {
        get => new Vector2Int(-direct + 3, direct % 2 * (1 - (direct >> 2 << 2)));
        set => direct = 2 - value.y + Mathf.Abs(value.x) * (value.x - 3);
    }
    public Queue<Vector2Int> inp;
    public int item;
    public int number;

    
    public Belt(Vector2Int direction, Vector2Int position)
    {
        item = 0;
        Position = position;
        direct = (2 - direction.y) + Mathf.Abs(direction.x) * (direction.x - 3);
        
        inp = new Queue<Vector2Int>();
        number = 0;//ConvejerManager.belts.Count;
        if (Matrix.type[position.x + Direction.x,position.y + Direction.y] != 0)
        {
            ConvejerManager.ends.Add(this);
        }
        ConvejerManager.belts.Add(this);
        foreach (Vector2Int dir in Matrix.directions)
        {
            if (dir != Direction && Matrix.type[position.x + dir.x,position.y + dir.y] != 0)
            {
                inp.Enqueue(dir);
            }
        }
        
    }
}

public class ConvejerManager : MonoBehaviour
{
    public static ConvejerManager solo;
    public static List<Belt> belts = new List<Belt>();
    public static List<Belt> ends = new List<Belt>();
    public List<Texture> beltTextures; 
    void Awake()
    {
        solo = this;
        belts.Add(new Belt(Vector2Int.up, new Vector2Int(1, 1)));
    }
    private void Update()
    {
        
    }
    private void Take(Belt conv)
    {
        conv.item = ConvejerManager.belts[Matrix.machine[conv.Position.x + conv.inp.Dequeue().x,conv.Position.y + conv.inp.Dequeue().y]].item;
        Send(ConvejerManager.belts[Matrix.machine[conv.Position.x + conv.inp.Dequeue().x,conv.Position.y + conv.inp.Dequeue().y]]);
    }

    private int Send(Belt conv)
    {
        int sent = conv.item;
        conv.item = 0;
        if (conv.inp.Count > 0) Take(conv);
        return sent; 
    }

    // Update is called once per frame
    public void Tick()
    {
        foreach(Belt end in ends)
        {
            Send(end);
        }
    }

    private void OnGUI()
    {
        if (Event.current.type.Equals(EventType.Repaint)) { 
            foreach (Belt belt in belts)
            {
                Draw(belt);
            }
        }
    }

    public void Draw(Belt belt)
    {
        float scale = CameraView.solo.scale;
        int x = (int)(belt.Position.x * scale);
        int y = (int)(belt.Position.y * scale);
        Graphics.DrawTexture(new Rect(32 ,32 ,32 ,32), beltTextures[0]);
    }
}
