using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.LiteScript.Compiler.CommandParser;

namespace craftersmine.LiteScript.Compiler.Init
{
    public sealed class CommandRegistrator
    {
        public static void RegisterAllCommands()
        {
            //CommandRegistry.RegisterCommand(new Command("Console.WriteLine({contents});", "Output:WriteLn[{contents}]", new string[] { "contents" }));
            //CommandRegistry.RegisterCommand(new Command("using {namespace};", "Use {namespace}", new string[] { "namespace" }));
            //CommandRegistry.RegisterCommand(new Command("{type} {name};", "InitializeVar {type} {name}", new string[] { "type", "name" }));
            //CommandRegistry.RegisterCommand(new Command("{name} = Console.ReadLine();", "{name}=Input:ReadLn[]", new string[] { "name" }));

            CommandRegistry.RegisterKeyword(new Keyword("class", "DefClass"));
            CommandRegistry.RegisterKeyword(new Keyword("public", "Visibility:Public"));
            CommandRegistry.RegisterKeyword(new Keyword("private", "Visibility:Private"));
            CommandRegistry.RegisterKeyword(new Keyword("protected", "Visibility:Protected"));
            CommandRegistry.RegisterKeyword(new Keyword("static", "StaticObj"));

            CommandRegistry.RegisterKeyword(new Keyword("void", "Void"));
            CommandRegistry.RegisterKeyword(new Keyword("string", "String"));
            CommandRegistry.RegisterKeyword(new Keyword("int", "Int32"));
            CommandRegistry.RegisterKeyword(new Keyword("short", "Int16"));
            CommandRegistry.RegisterKeyword(new Keyword("long", "Long"));
            CommandRegistry.RegisterKeyword(new Keyword("char", "Character"));
            CommandRegistry.RegisterKeyword(new Keyword("object", "Object"));
            CommandRegistry.RegisterKeyword(new Keyword("var", "Variable"));

            CommandRegistry.RegisterKeyword(new Keyword("sealed", "NonInheritable"));
            CommandRegistry.RegisterKeyword(new Keyword("abstract", "Abstract"));

            CommandRegistry.RegisterKeyword(new Keyword("using", "Use"));
            CommandRegistry.RegisterKeyword(new Keyword("namespace", "Namespace"));

            CommandRegistry.RegisterKeyword(new Keyword("delegate", "Delegate"));
            CommandRegistry.RegisterKeyword(new Keyword("enum", "Enumeration"));

            CommandRegistry.RegisterKeyword(new Keyword("if", "[IF]"));
            CommandRegistry.RegisterKeyword(new Keyword("else if", "[ELSE_IF]"));
            CommandRegistry.RegisterKeyword(new Keyword("else", "[ELSE]"));

            CommandRegistry.RegisterKeyword(new Keyword("for", "For"));
            CommandRegistry.RegisterKeyword(new Keyword("foreach", "ForEach"));
            CommandRegistry.RegisterKeyword(new Keyword("while", "DoWhile"));

            CommandRegistry.RegisterKeyword(new Keyword("try", "TryDo"));
            CommandRegistry.RegisterKeyword(new Keyword("catch", "CatchException"));
            CommandRegistry.RegisterKeyword(new Keyword("finally", "DoFinally"));

            CommandRegistry.RegisterKeyword(new Keyword("interface", "DefInterface"));

            CommandRegistry.RegisterKeyword(new Keyword("switch", "Switch"));
            CommandRegistry.RegisterKeyword(new Keyword("case", "Case"));
            CommandRegistry.RegisterKeyword(new Keyword("break", "BreakConstruction"));
            CommandRegistry.RegisterKeyword(new Keyword("default", "DefaultCase"));
            CommandRegistry.RegisterKeyword(new Keyword("continue", "Continue"));

            CommandRegistry.RegisterKeyword(new Keyword("return", "Return"));
            CommandRegistry.RegisterKeyword(new Keyword("event", "Event"));
            CommandRegistry.RegisterKeyword(new Keyword("null", "NullValue"));
        }
    }
}