using System;
using System.Collections.Generic;
using System.Text;
using VladislavTsurikov.CsCodeGenerator.Runtime.Utility;

namespace VladislavTsurikov.CsCodeGenerator.Runtime
{
    public class FileModel
    {
        private List<string> UsingDirectives { get; set; } = new List<string>();
        
        public bool WarningGeneratedFile = true;

        public List<string> PreprocessorDirectives { get; set; } = new List<string>();

        public string Namespace { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; } = Util.CsExtension;

        public string FullName => Name + "." + Extension;

        public List<EnumModel> Enums { get; set; } = new List<EnumModel>();

        public List<ClassModel> Classes { get; set; } = new List<ClassModel>();
        
        public FileModel(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string result = WarningGeneratedFile ? GetWarningGeneratedFileText() : "";
            
            foreach (var preprocessorDirective in PreprocessorDirectives)
            {
                result += "#if " + preprocessorDirective + Util.NewLine;
            }
            
            string usingText = UsingDirectives.Count > 0 ? Util.Using + " " : "";
            result += usingText + String.Join(Util.NewLine + usingText, UsingDirectives);
            result += Util.NewLineDouble + Util.Namespace + " " + Namespace;
            result += Util.NewLine + "{";
            result += String.Join(Util.NewLine, Enums);
            result += (Enums.Count > 0 && Classes.Count > 0) ? Util.NewLine : "";
            result += String.Join(Util.NewLine, Classes);
            result += Util.NewLine + "}";
            result += Util.NewLine;
            
            foreach (var preprocessorDirective in PreprocessorDirectives)
            {
                result += "#endif" + Util.NewLine;
            }
            
            return result;
        }

        public void LoadUsingDirectives(List<string> usingDirectives)
        {
            foreach (var usingDirective in usingDirectives)
            {
                UsingDirectives.Add(usingDirective + ";");
            }
        }
        
        public void LoadUsingDirectives(params Type[] types)
        {
            foreach (var usingDirective in NamespaceUtility.GetUsingDirectives(types))
            {
                UsingDirectives.Add(usingDirective + ";");
            }
        }
        
        public void SetNamespaceFromFolder(string path, params string[] ignoredFolders)
        {
            Namespace = NamespaceUtility.GetNamespaceFromPath(path, "VladislavTsurikov", ignoredFolders);
        }

        private string GetWarningGeneratedFileText()
        {
            var namesStringBuilder = new StringBuilder();
            
            namesStringBuilder.AppendLine("//.........................");
            namesStringBuilder.AppendLine("//.....Generated File......");
            namesStringBuilder.AppendLine("//.........................");
            namesStringBuilder.AppendLine("//.......Do not edit.......");
            namesStringBuilder.AppendLine("//.........................");

            return namesStringBuilder + Util.NewLine;
        }
    }
}
