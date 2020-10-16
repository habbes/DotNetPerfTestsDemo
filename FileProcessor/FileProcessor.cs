using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileProcessor
{
    public class FileProcessor
    {
        public string GetNamesList(Stream input)
        {
            List<string> names = new List<string>();
            var reader = new StreamReader(input);

            string content = reader.ReadToEnd();

            var lines = content.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                var words = line.Split(" ");
                foreach (var word in words)
                {
                    if (word.StartsWith("name:"))
                    {
                        var name = word.Split(':')[1];
                        names.Add(name);
                    }
                }
            }

            return string.Join(' ', names);
        }
    }
}
