namespace GameCore
{
    public interface IMorty

    {

        public List<int> mortyValues { get; set; }
        public List<string> hmacs { get; set; }
        public List<byte[]> secretKeys { get; set; }
        public List<int> fairValues { get; set; }

        public void GenerateValues(int boxCount, int i);

    }
}

