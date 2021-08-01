using System;
using System.IO;

namespace PluralkitAPI.Environment
{
    public static class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('=',
                                            StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                {
                    continue;
                }

                System.Environment.SetEnvironmentVariable(parts[0], parts[1]);
                _ = System.Environment.GetEnvironmentVariable(parts[0]);
            }
        }
    }
}