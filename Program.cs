namespace Project01
{
    class Program
    {
        static readonly char[] transcode = new char[67];

        private static void Prep()
        {
            for (int i = 0; i < 64; i++)
            {
                transcode[i] = (char)('A' + i);
                if (i > 25) transcode[i] = (char)(transcode[i] + 6);
                if (i > 51) transcode[i] = (char)(transcode[i] - 0x4b);
            }

            transcode[64] = '+';
            transcode[65] = '/';
            transcode[66] = '=';
        }

        static void Main(string[] args)
        {
            Prep();

            var testString = "BlaBlaCar";

            var encodeResult = Encoder.Encode(testString, transcode);
            var decodeResult = Decoder.Decode(encodeResult, transcode);

            if (decodeResult.Equals(testString))
            {
                Console.WriteLine("Test succeeded");
            }
            else
            {
                Console.WriteLine("Test failed");
            }

            Console.ReadLine();
        }
    }
}