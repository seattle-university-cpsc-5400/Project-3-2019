using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
   
    public abstract class SymTab
    {

        public abstract int CurrentNestLevel { get; }

        public virtual void @out(string s)
        {
            string tab = "";
            for (int i = 1; i <= CurrentNestLevel; ++i)
            {
                tab += "  ";
            }
            Console.WriteLine(tab + s);
        }

        public virtual void err(string s)
        {
            @out("Error: " + s);
            Console.Error.WriteLine("Error: " + s);
            Environment.Exit(-1);
        }

        // public virtual void @out(AbstractNode n, string s)
        // {
        //@out("" + n.NodeNum + ": " + s + " " + n);
        // }
        // public virtual void err(AbstractNode n, string s)
        // {
        //err("" + n.NodeNum + ": " + s + " " + n);
        // }

    }
    public class SymbolTable : SymTab, SymtabInterface
    {

        /// <summary>
        /// Should never return a negative integer 
        /// </summary>
        protected static int nestLevel = 0;
        protected List<Hashtable> SymTblList = new List<Hashtable>();
        public void BuildTree()
        {
            TypeAttributes attr = new TypeAttributes(new IntegerTypeDescriptor());
            enter("INT", attr);
            attr = new TypeAttributes(new BooleanTypeDescriptor());
            enter("BOOLEAN", attr);
            attr = new TypeAttributes(new VoidTypeDescriptor());
            enter("VOID", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("java", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("io", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("PrintStream", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("lang", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("System", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("out", attr);
            attr = new TypeAttributes(new JavaInternalTypeDescriptor());
            enter("print", attr);
            attr = new TypeAttributes(new MSCorLibTypeDescriptor());
            enter("Write", attr);
            attr = new TypeAttributes(new MSCorLibTypeDescriptor());
            enter("WriteLine", attr);
            attr = new TypeAttributes(new StringTypeDescriptor());
            enter("String", attr);
        }
        public override int CurrentNestLevel
        {
            get
            {
                return nestLevel; // you must fix this
            }
        }

        /// <summary>
        /// Opens a new scope, retaining outer ones </summary>

        public virtual void incrNestLevel()
        {
            Hashtable temp = new Hashtable();
            SymTblList.Add(temp);
            ++nestLevel;
        }

        /// <summary>
        /// Closes the innermost scope </summary>

        public virtual Hashtable decrNestLevel()
        {
            Hashtable result = SymTblList[CurrentNestLevel - 1];
            SymTblList.RemoveAt(nestLevel - 1);
            --nestLevel;
            return result;
        }

        /// <summary>
        /// Enter the given symbol information into the symbol table.  If the given
        ///    symbol is already present at the current nest level, do whatever is most
        ///    efficient, but do NOT throw any exceptions from this method.
        /// </summary>

        public virtual void enter(string s, Attributes info)
        {
            if (SymTblList[CurrentNestLevel - 1].ContainsKey(s))
            {
                throw new FoundKeyException("Symbol "+ s +" already declared");
            }
            else
            {
                SymTblList[CurrentNestLevel - 1].Add(s, info);
            }
        }

        /// <summary>
        /// Returns the information associated with the innermost currently valid
        ///     declaration of the given symbol.  If there is no such valid declaration,
        ///     return null.  Do NOT throw any excpetions from this method.
        /// </summary>

        public virtual Attributes lookup(string s)
        {
            for (int i = SymTblList.Count - 1; i >= 0; i--)
            {
                if (SymTblList[i] != null && SymTblList[i].ContainsKey(s))
                    return (Attributes)(SymTblList[i])[s];
            }
            return null;
        }
        public virtual bool declaredLocally(string s)
        {
            return SymTblList[CurrentNestLevel - 1].ContainsKey(s);
        }
        public void PrintTable()
        {
            Attributes attr; 
            foreach(Hashtable table in SymTblList)
            {
                foreach (object item in table.Keys)
                {
                    attr = lookup((string)item);
                    Console.Write((string)item + "   ");
                    attr.TypeRef.PrintType();
                }
            }
            Console.WriteLine();
        }
    }
    public class FoundKeyException : Exception
    {
        public FoundKeyException(string message) : base(message) { }
    }

}
