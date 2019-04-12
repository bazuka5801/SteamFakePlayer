namespace AutoRegger
{
    public struct Rect {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }

        public override string ToString() => $"x:{Left} y:{Top} width:{Right - Left} height:{Bottom - Top}";
    }
}