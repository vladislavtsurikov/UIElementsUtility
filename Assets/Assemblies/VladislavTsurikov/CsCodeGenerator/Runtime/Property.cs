using System;
using VladislavTsurikov.CsCodeGenerator.Runtime.Enums;

namespace VladislavTsurikov.CsCodeGenerator.Runtime
{
    public class Property : Field
    {
        private bool _isAutoImplemented;
        
        public override bool HasAttributes => true;

        public override AccessModifier AccessModifier { get; set; } = AccessModifier.Public;

        public bool IsGetOnly { get; set; }

        public bool IsAutoImplemented => string.IsNullOrEmpty(GetterBody) && string.IsNullOrEmpty(SetterBody);

        public string GetterBody { get; set; }

        public string SetterBody { get; set; }

        protected override string Ending => DefaultValue != null ? ";" : "";

        public override string Body
        {
            get
            {
                if (IsAutoImplemented)
                {
                    return IsGetOnly ? " { get; }" : " { get; set; }";
                }
                else
                {
                    if (IsGetOnly)
                    {
                        return " => " + GetterBody + ";";
                    }
                    else
                    {
                        string result = Util.NewLine + Indent + "{";
                        string currentIndent = Util.NewLine + Indent + CsGenerator.IndentSingle;
                    
                        result += currentIndent + "get { return " + GetterBody + "; }";
                        result += currentIndent + "set { " + SetterBody + "; }";
                        result += Util.NewLine + Indent + "}";

                        return result;
                    }
                }
            } 
        }
        
        public Property() { }

        public Property(BuiltInDataType builtInDataType, string name) : base(builtInDataType, name) { }

        public Property(Type customDataType, string name) : base(customDataType, name) { }
    }
}
