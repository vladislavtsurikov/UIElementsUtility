﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace VladislavTsurikov.CsCodeGenerator.Runtime
{
    public class CsGenerator
    {
        public static int DefaultTabSize = 4;
        public static string IndentSingle => new String(' ', DefaultTabSize);
        public string Path { get; set; }
        public List<FileModel> Files { get; set; } = new List<FileModel>();

        public void CreateFiles()
        {
            if (!Directory.Exists(Path))
            {
                string message = "Path not valid: " + Path;
                Console.WriteLine(message);
                throw new InvalidOperationException(message);
            }

            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            foreach (var file in Files)
            {
                string filePath = $@"{Path}\{file.FullName}";
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.Write(file);
                }
            }
            
#if UNITY_EDITOR
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }
    }
}
