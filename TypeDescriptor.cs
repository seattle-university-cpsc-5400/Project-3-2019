using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
    /******************************************/
    /*Describes type of node for decorated AST*/
    /******************************************/
    public abstract class TypeDescriptor
    {
        public string type;
        public void PrintType()
        {
            Console.WriteLine("    " + this.GetType().ToString());
        }
    }
    /******************************************/
    /*********Basic Primitive Types************/
    /******************************************/
    public class IntegerTypeDescriptor : TypeDescriptor
    {
        int value;
        public IntegerTypeDescriptor()
        {
            type = "int32";
        }

        public int Value { get { return value; } set { this.value = value; } }
    }
    public class StringTypeDescriptor : TypeDescriptor
    {
        int value;
        public StringTypeDescriptor()
        {
            type = "string";
        }

        public int Value { get { return value; } set { this.value = value; } }
    }
    public class BooleanTypeDescriptor : TypeDescriptor
    {
        bool value;
        public BooleanTypeDescriptor()
        {
            type = "bool";
        }
        public bool Value { get { return value; } set { this.value = value; } }
    }
    public class VoidTypeDescriptor : TypeDescriptor
    {
        public VoidTypeDescriptor()
        {
            type = "void";
        }
    }

   
    /*****MSCoreLib Type Descriptor for mscorlib code generation*****/
    public class MSCorLibTypeDescriptor : TypeDescriptor
    {
        public MSCorLibTypeDescriptor()
        {
            type = "void [mscorlib]System.Console::";
        }
    }
    /*****Error Type Descriptor*****/
    public class ErrorTypeDescriptor : TypeDescriptor
    {
    }

    
}
