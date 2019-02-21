using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EFCore.TextTemplating.Design
{
    abstract class MyCodeGeneratorBase
    {
        bool _endsWithNewline;
        string _currentIndent = "";

        public virtual IDictionary<string, object> Session { get; set; }

        protected StringBuilder GenerationEnvironment { get; set; } = new StringBuilder();

        public abstract string TransformText();

        //    private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        //    private global::System.Collections.Generic.List<int> indentLengthsField;

        //    public System.CodeDom.Compiler.CompilerErrorCollection Errors
        //    {
        //        get
        //        {
        //            if ((this.errorsField == null))
        //            {
        //                this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
        //            }
        //            return this.errorsField;
        //        }
        //    }

        //    private System.Collections.Generic.List<int> indentLengths
        //    {
        //        get
        //        {
        //            if ((this.indentLengthsField == null))
        //            {
        //                this.indentLengthsField = new global::System.Collections.Generic.List<int>();
        //            }
        //            return this.indentLengthsField;
        //        }
        //    }

        //    public string CurrentIndent
        //    {
        //        get
        //        {
        //            return this.currentIndentField;
        //        }
        //    }



        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
                return;

            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (GenerationEnvironment.Length == 0 || _endsWithNewline)
            {
                GenerationEnvironment.Append(_currentIndent);
                _endsWithNewline = false;
            }

            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
            {
                _endsWithNewline = true;
            }

            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if (_currentIndent.Length == 0)
            {
                GenerationEnvironment.Append(textToAppend);

                return;
            }

            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(Environment.NewLine, Environment.NewLine + _currentIndent);

            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (_endsWithNewline)
            {
                GenerationEnvironment.Append(textToAppend, 0, textToAppend.Length - _currentIndent.Length);
            }
            else
            {
                GenerationEnvironment.Append(textToAppend);
            }
        }

        //    public void WriteLine(string textToAppend)
        //    {
        //        this.Write(textToAppend);
        //        this.GenerationEnvironment.AppendLine();
        //        this.endsWithNewline = true;
        //    }

        //    public void Write(string format, params object[] args)
        //    {
        //        this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        //    }

        //    public void WriteLine(string format, params object[] args)
        //    {
        //        this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        //    }

        //    public void Error(string message)
        //    {
        //        System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
        //        error.ErrorText = message;
        //        this.Errors.Add(error);
        //    }

        //    public void Warning(string message)
        //    {
        //        System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
        //        error.ErrorText = message;
        //        error.IsWarning = true;
        //        this.Errors.Add(error);
        //    }

        //    public void PushIndent(string indent)
        //    {
        //        if ((indent == null))
        //        {
        //            throw new global::System.ArgumentNullException("indent");
        //        }
        //        this.currentIndentField = (this.currentIndentField + indent);
        //        this.indentLengths.Add(indent.Length);
        //    }

        //    public string PopIndent()
        //    {
        //        string returnValue = "";
        //        if ((this.indentLengths.Count > 0))
        //        {
        //            int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
        //            this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
        //            if ((indentLength > 0))
        //            {
        //                returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
        //                this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
        //            }
        //        }
        //        return returnValue;
        //    }

        //    public void ClearIndent()
        //    {
        //        this.indentLengths.Clear();
        //        this.currentIndentField = "";
        //    }

        public class ToStringInstanceHelper
        {
            IFormatProvider _formatProvider = CultureInfo.InvariantCulture;

            //        public System.IFormatProvider FormatProvider
            //        {
            //            get
            //            {
            //                return this.formatProviderField ;
            //            }
            //            set
            //            {
            //                if ((value != null))
            //                {
            //                    this.formatProviderField  = value;
            //                }
            //            }
            //        }

            public string ToStringWithCulture(object objectToConvert)
            {
                if (objectToConvert == null)
                    throw new ArgumentNullException(nameof(objectToConvert));

                var method = objectToConvert.GetType().GetMethod("ToString", new[] { typeof(IFormatProvider) });
                if (method == null)
                    return objectToConvert.ToString();

                return (string)method.Invoke(objectToConvert, new[] { _formatProvider });
            }
        }

        public ToStringInstanceHelper ToStringHelper { get; } = new ToStringInstanceHelper();
    }
}
