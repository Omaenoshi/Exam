using System.Collections.Generic;

namespace Sort
{
    public class Vertex
    {
        public int Value { get; }
        
        public Vertex Right { get; set; }
        
        public Vertex Left { get; set; }

        public Vertex(int value) => Value = value;

        public void Insert(int value)
        {
            if (value < Value)
            {
                if (Left == null)
                    Left = new Vertex(value);
                else
                    Left.Insert(value);
            }
            else
            {
                if (Right is null)
                    Right = new Vertex(value);
                else
                    Right.Insert(value);
            }
        }

        public int[] Parse(List<int> array)
        {
            if (Left is not null)
                Left.Parse(array);
            
            array.Add(Value);
            
            if (Right is not null)
                Right.Parse(array);

            return array.ToArray();
        }
    }
}
