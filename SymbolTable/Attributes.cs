using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
    /****************************************************/
    /*Information symbols held in nodes and symbol table*/
    /****************************************************/
    public abstract class Attributes
    {
        protected TypeDescriptor typeRef;
        protected int location;
        protected string codeType;
        public Attributes(TypeDescriptor typeRef = null)
        {
            this.typeRef = typeRef;
        }
        public TypeDescriptor TypeRef
        {
            get { return typeRef; }
            set { this.typeRef = value; }
        }
        public int Location
        {
            get { return location; }
            set { this.location = value; }
        }
        public string CodeType
        {
            get { return codeType; }
            set { this.codeType = value; }
        }
    }
    public class VariableAttributes : Attributes
    {
        private List<string> list;
        public VariableAttributes(List<string> list = null, TypeDescriptor type = null) : base(type)
        {
            this.list = list;
        }
        public List<string> ListRef
        {
            get { return list; }
            set { this.list = value; }
        }
    }
    public class TypeAttributes : Attributes
    {
        public TypeAttributes(TypeDescriptor type = null) : base(type) { }
    }
    public class ClassAttributes : Attributes
    {
        public ClassAttributes(TypeDescriptor type = null) : base(type) { }
    }
    public class MethodAttributes : Attributes
    {
        private TypeDescriptor signature;
        private TypeDescriptor returnType;
        private Hashtable locals;
        private ClassAttributes isDefinedIn;
        private List<string> mods;
        public MethodAttributes() { }
        public TypeDescriptor Signature { get { return signature; } set { this.signature = value; } }
        public TypeDescriptor ReturnType { get { return returnType; } set { this.returnType = value; } }
        public Hashtable Locals { get { return locals; } set { this.locals = value; } }
        public ClassAttributes IsDefinedIn { get { return isDefinedIn; } set { this.isDefinedIn = value; } }
        public List<string> Mods { get { return mods; } set { this.mods = value; } }
    }
}
