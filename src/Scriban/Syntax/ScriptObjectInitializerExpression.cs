﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license. 
// See license.txt file in the project root for full license information.

using System.Collections.Generic;
using Scriban.Runtime;

namespace Scriban.Syntax
{
    [ScriptSyntax("object initializer expression", "{ member1: <expression>, member2: ... }")]
    public class ScriptObjectInitializerExpression : ScriptExpression
    {
        public ScriptObjectInitializerExpression()
        {
            Members = new Dictionary<ScriptExpression, ScriptExpression>();
        }

        public Dictionary<ScriptExpression, ScriptExpression> Members { get; private set; }

        public override object Evaluate(TemplateContext context)
        {
            var scriptObject = new ScriptObject();
            foreach (var member in Members)
            {
                var variable = member.Key as ScriptVariable;
                var literal = member.Key as ScriptLiteral;

                var name = variable?.Name ?? literal?.Value?.ToString();
                scriptObject.SetValue(context, Span, name, context.Evaluate(member.Value), false);
            }
            return scriptObject;
        }

        public override string ToString()
        {
            return "{...}";
        }
    }
}