namespace Day2
{
  internal class Position
  {
    public int Horizontal { get; internal set; }
    public int Depth { get; internal set; }
    public int Aim { get; internal set; }
    private Engine Engine { get; }

    public Position(Engine engine)
    {
      Engine = engine;
    }

    internal void Translate(Vector vector)
    { 
      Engine.Get(vector.Direction).Invoke(this, vector.Magnitude);
    }
  }
}