using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTBuilder
{
    public class SemanticsVisitor : IReflectiveVisitor
    {
        // This method is the key to implenting the Reflective Visitor pattern
        // in C#, using the 'dynamic' type specification to accept any node type.
        // The subsequent call to VisitNode does dynamic lookup to find the
        // appropriate Version.
        protected static SymbolTable table = new SymbolTable();
        public virtual void Visit(dynamic node)
        {
            this.VisitNode(node);
        }

        protected static MethodAttributes currentMethod = null;
        protected void SetCurrentMethod(MethodAttributes m)
        {
            currentMethod = m;
        }
        protected MethodAttributes GetCurrentMethod()
        {
            return currentMethod;
        }

        // *** You will need the following if you implement classes.

        //protected static ClassAttributes currentClass = null;

        //protected void SetCurrentClass(ClassAttributes c)
        //{
        //    currentClass = c;
        //}
        //protected ClassAttributes GetCurrentClass()
        //{
        //    return currentClass;
        //}

        // Call this method to begin the semantic checking process
        public void CheckSemantics(AbstractNode node)
        {
            if (node == null)
            {
                return;
            }
            TopDeclVisitor visitor = new TopDeclVisitor();
            node.Accept(visitor);
        }

        public virtual void VisitNode(AbstractNode node)
        {
            VisitChildren(node);
        }
        public virtual void VisitChildren(AbstractNode node)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("< In SemanticsVisitor.VistChildren for " + node.ClassName() + " >");
            Console.ResetColor();

            AbstractNode child = node.Child;
            while (child != null)
            {
                child.Accept(this);
                child = child.Sib;
            };
        }
        //Starting Node of an AST
        public void VisitNode(CompilationUnit node)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("< In SemanticsVisitor.VisitNode for " + node.ClassName() + " >");
            Console.ResetColor();

            TopDeclVisitor visitor = new TopDeclVisitor();
            AbstractNode child = node.Child;
            while (child != null)
            {
                child.Accept(visitor);
                child = child.Sib;
            };
        }
        public virtual void VisitNode(Identifier node)
        {

        }


    }
    public class LHSSemanticVisitor : SemanticsVisitor
    {
        public override void Visit(dynamic node)
        {
            this.VisitNode(node);
        }
        //check if Identifier is declared in Symbol table and assignable
        public override void VisitNode(Identifier node)
        {
            
        }

        bool isAssignable(Attributes attr)
        {
            return false;
        }
    }

    public class TopDeclVisitor : SemanticsVisitor
    {
        public override void Visit(dynamic node)
        {
            this.VisitNode(node);
        }

        public override void VisitNode(AbstractNode node)
        {
            VisitChildren(node);
        }

        //define method attribute, increase scope, and check body 
        public void VisitNode(MethodDeclaration node)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("< In TopDeclVisitor.VisitNode for " + node.ClassName() + " >");
            Console.ResetColor();

            VisitChildren(node);
        }

        public virtual void VisitNode(PrimitiveType node)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("< In TopDeclVisitor.VisitNode for " + node.ClassName() + " >");
            Console.ResetColor();
        }
    }

    public class TypeVisitor : TopDeclVisitor
    {
        public override void Visit(dynamic node)
        {
            this.VisitNode(node);
        }

        //check if identifier is in symbol table 
        public override void VisitNode(Identifier node)
        {
           
        }

        //check if primitive type is in symbol table and get type from its attribute
        public override void VisitNode(PrimitiveType node)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("< In TypeVisitor.VisitNode for " + node.ClassName() + " >");
            Console.ResetColor();
        }
    }
}
    