namespace OOADandPatterns.Patterns.CodeForSomePatterns
{
    internal class Point1
    {
        public Point1(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        protected bool Equals(Point1 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Point1) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X*397) ^ Y;
            }
        }
    }

    internal class Point2
    {
        private readonly int x, y;

        public Point2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        public Point2 Move(int dx, int dy)
        {
            return new Point2(x + dx, y + dy);
        }

        protected bool Equals(Point2 other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Point2) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x*397) ^ y;
            }
        }
    }
}