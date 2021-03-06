﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license. 
// See license.txt file in the project root for full license information.

namespace Scriban.Syntax
{
    [ScriptSyntax("member expression", "<expression>.<variable_name>")]
    public class ScriptMemberExpression : ScriptVariablePath
    {
        public ScriptExpression Target { get; set; }

        public ScriptVariable Member { get; set; }

        public override object Evaluate(TemplateContext context)
        {
            return context.GetValue(this);
        }

        public override string ToString()
        {
            return $"{Target}.{Member}";
        }
    }
}