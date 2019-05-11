using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
    public interface SymtabInterface
    {
        /// Open a new nested symbol table
        void incrNestLevel();

        /// Close an existing nested symbol table
        Hashtable decrNestLevel();

        int CurrentNestLevel { get; }

        Attributes lookup(string id);

        void enter(string id, Attributes s);

        /// This lets you put out a message about a node, indented by the current nest level 
        //    void @out(AbstractNode n, string message);
        //    void err(AbstractNode n, string message);
        void @out(string message);
        void err(string message);
    }
    
}
