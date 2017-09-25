using System;
using System.Collections;
using System.Collections.Generic;

namespace radixtree
{
	class RadixTree
	{
		static string [] _StrArray = new [] { "Armor", "Armor", "Big", "Barack", "Band", "Build" };

		public class Node
		{
			public char _Character;
			public List<Node> _Children = new List<Node>();
		}

		public static void Main (string[] args)
		{
			Node root = new Node();

			int charIndex = 0;
			foreach(string str in _StrArray)
			{
				FindNodeInTree(root, str, ref charIndex);
				charIndex = 0;
			}

			DisplayTreeData(root);

			Console.ReadLine();
		}

		public static void DisplayTreeData(Node parent)
		{
			foreach(Node child in parent._Children)
			{
				Console.WriteLine(child._Character + " : " + parent._Character);
				DisplayTreeData(child);
			}
		}

		public static void FindNodeInTree(Node parent, string str, ref int charIndex)
		{
			foreach(Node child in parent._Children)
			{
				if(child._Character == str[charIndex])
				{
					charIndex++;
					FindNodeInTree(child, str,ref charIndex);
					return;
				}
			}

			CreateNodeInTree(parent, str, charIndex);
		}

		public static void CreateNodeInTree(Node parent, string str, int charIndex)
		{
			for(int i=charIndex; i<str.Length;i++)
			{
				Node node = new Node();
				node._Character = str[i];

				parent._Children.Add(node);

				parent = node;
			}
		}
	}
}
