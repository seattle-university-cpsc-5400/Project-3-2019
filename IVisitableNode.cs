using System;

namespace ASTBuilder
{
	/// <summary> Reflective visitor pattern -- a node must accept a visitor </summary>
	public interface IVisitableNode
	{
	   void Accept(IReflectiveVisitor rv);
	}

    public interface IReflectiveVisitor
    {
        void Visit(dynamic node);
        
    }

}