using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
    /****************************************************/
    /*Information about symbols held in AST nodes and the symbol table*/
    /****************************************************/
    public abstract class Attributes
    {
        
        public Attributes() 
        {
           
        }
       
    }
    public class VariableAttributes : Attributes
    {
        public VariableAttributes() { }
    }

    public class TypeAttributes : Attributes
    {
        public TypeAttributes(TypeDescriptor type)
        {
        }
    }
    
    public class MethodAttributes : Attributes
    {

    }
}
