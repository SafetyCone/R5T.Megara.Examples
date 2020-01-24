using System;
using System.Collections.Generic;
using System.IO;

using R5T.Magyar.IO;
using R5T.Tiros;


namespace R5T.Megara.Examples.Lib
{
    public class LinesTextSerializer : ITextSerializer<List<string>>
    {
        public List<string> Deserialize(TextReader reader)
        {
            var output = new List<string>();

            while(reader.ReadLine(out var line))
            {
                output.Add(line);
            }

            return output;
        }

        public void Serialize(TextWriter writer, List<string> value)
        {
            foreach (var line in value)
            {
                writer.WriteLine(line);
            }
        }
    }
}
