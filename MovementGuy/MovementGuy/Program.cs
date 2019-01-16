namespace MovementGuy
{
#if WINDOWS
    static class Program
    {
        static void Main(string[] args)
        {
            using (Main game = new Main())
            {
                game.Run();
            }
        }
    }
#endif
}

