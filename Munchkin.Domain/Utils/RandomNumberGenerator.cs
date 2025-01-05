namespace Munchkin.Domain.Utils
{
    public static class RandomNumberGenerator
    {
        public static int GenerateNumberFrom1To100()
        {
            Random random = new Random();

            return random.Next(1, 101);
        }

        public static int GenerateNumberFrom1To10()
        {
            Random random = new Random();

            return random.Next(1, 11);
        }
    }
}
