namespace Project01
{
    public static class Decoder
    {
        public static string Decode(string input, char[] transcode)
        {
            int l = input.Length;
            var output = new List<char>();

            int c = 0;
            int bits = 0;
            int reflex = 0;
            for (int j = 0; j < l; j++)
            {
                reflex <<= 6;
                bits += 6;
                bool fTerminate = ('=' == input[j]);
                if (fTerminate) break;

                reflex += IndexOf(input[j], transcode);
                while (bits >= 8)
                {
                    int mask = 0x000000ff << (bits % 8);
                    output.Add((char)((reflex & mask) >> (bits % 8)));

                    int invert = ~mask;
                    reflex &= invert;
                    bits -= 8;
                }
            }

            Console.WriteLine("{0} --> {1}\n", input, new string(output.ToArray()));
            return new string(output.ToArray());
        }

        private static int IndexOf(char ch, char[] transcode)
        {
            int index;
            for (index = 0; index < transcode.Length; index++)
                if (ch == transcode[index])
                    break;
            return index;
        }
    }
}
