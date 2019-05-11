using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
   
    public class SymbolTable : SymtabInterface
    {

        /// <summary>
        /// Should never be a negative integer 
        /// </summary>
        protected static int nestLevel = 0;
        
        // *** Declarations for your chosen implementation of the 
        // *** symbol table go here.  Some part of this implementation
        // *** should be what gets saved when a symbol table becomes
        // *** part of the Attributes of something like a class

        public SymbolTable ()
        {
            // *** Do any  initialization necessary to create a global 
            // *** name scopre and then initialize it with built-in names ...
            EnterPredefinedNames();

        }
        /// <summary>
        /// Enter predefined names into symbol table.  
        /// </summary>
        public void EnterPredefinedNames()
        {
            TypeAttributes attr = new TypeAttributes(new IntegerTypeDescriptor());
            enter("INT", attr);
            attr = new TypeAttributes(new BooleanTypeDescriptor());
            enter("BOOLEAN", attr);
            attr = new TypeAttributes(new VoidTypeDescriptor());
            enter("VOID", attr);
            attr = new TypeAttributes(new StringTypeDescriptor());
            enter("String", attr);
            attr = new TypeAttributes(new MSCorLibTypeDescriptor());
            enter("Write", attr);
            attr = new TypeAttributes(new MSCorLibTypeDescriptor());
            enter("WriteLine", attr);
        }
        public int CurrentNestLevel
        {
            get
            {
                return nestLevel; 
            }
        }

        /// <summary>
        /// Opens a new scope, retaining outer ones </summary>
        public virtual void incrNestLevel()
        {
             
        }

        /// <summary>
        /// Closes the innermost scope and returns the HashTable used to implement the scope
        /// </summary>
        public virtual Hashtable decrNestLevel()
        {

            return null;  //necessary so that this method compiles until you implement it.
        }

        /// <summary>
        /// Enter the given symbol information into the symbol table.  If the given
        ///    symbol is already present at the current nest level, produce an error
        ///    message, but do NOT throw any exceptions from this method.
        /// </summary>
        public virtual void enter(string s, Attributes info)
        {
             
        }

        /// <summary>
        /// Returns the information associated with the innermost currently valid
        ///     declaration of the given symbol.  If there is no such valid declaration,
        ///     return null.  Do NOT throw any excpetions from this method.
        /// </summary>
        public virtual Attributes lookup(string s)
        {
            //if name s is not found, return null Attributes reference
            return null;
        }

        public virtual bool declaredLocally(string s)
        {
            return false;
        }

        public void PrintTable()
        {
             
        }
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
    

}
