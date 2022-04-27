using System;
using System.Collections.Generic;
using System.IO;

using R5T.Magyar.IO;
using R5T.Tiros;using R5T.T0064;


namespace R5T.Megara.Examples.Lib
{[ServiceImplementationMarker]
    public class LinesTextSerializer : ITextSerializer<List<string>>,IServiceImplementation
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
