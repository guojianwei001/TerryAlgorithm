using System;
using System.Linq.Expressions;
using TerryAlgorithm.BinaryTree;

namespace TerryAlgorithm
{
    partial class Program
    {
        public class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int Age { get; set; }
        }

        public static Func<string, string?> ConstructGreetingFunction()
        {
            var personNameParameter = Expression.Parameter(typeof(string), "personName");

            // Condition
            var isNullOrWhiteSpaceMethod = typeof(string)
                .GetMethod(nameof(string.IsNullOrWhiteSpace));

            var condition = Expression.Not(
                Expression.Call(isNullOrWhiteSpaceMethod, personNameParameter));

            // True clause
            var concatMethod = typeof(string)
                .GetMethod(nameof(string.Concat), new[] { typeof(string), typeof(string) });

            var trueClause = Expression.Call(
                concatMethod,
                Expression.Constant("Greetings, "),
                personNameParameter);

            // False clause
            var falseClause = Expression.Constant(null, typeof(string));

            var conditional = Expression.Condition(condition, trueClause, falseClause);

            var lambda = Expression.Lambda<Func<string, string?>>(conditional, personNameParameter);

            Console.WriteLine(lambda);

            return lambda.Compile();
        }

        static void Main(string[] args)
        {
            var treeBuilder = new BinaryTreeBuilder("+*A@@-B@@C@@+D@@E@@");
            var tree = treeBuilder.Build();

            TreeTraversal<string>.PreorderNoRecursive(tree);
            Console.WriteLine();
            TreeTraversal<string>.InorderNoRecursive(tree);
            Console.WriteLine();
            TreeTraversal<string>.PostorderNoRecursive(tree);

            return;

            var getGreetings = ConstructGreetingFunction();

            var greetingsForJohn = getGreetings("John"); // "Greetings, John"
            var greetingsForNobody = getGreetings(" ");  // <null>

            //DoubledispatchTest.test();
            //TestBinaryTreeTraverse();

            //TestHitCounter();

            //TestSlidingBuffer();

            //testLRU();

            //comb("ABCDEFGH", ""); //C(5,3)

            //testBuildNumberTree(20);

            //testFun();
            //F2();
            //var treeNode = buildTree();
            //traverse(treeNode);

            //calc(5);
            //minimumWeight(5, 60);
            //mergeArraysTest();
            //mergeListsTest();
            //testLongestSubStr();
        }

        static void expressionTest()
        {
            // The block expression allows for executing several expressions sequentually.
            // When the block expression is executed,
            // it returns the value of the last expression in the sequence.
            BlockExpression blockExpr = Expression.Block(
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
                    Expression.Constant("Hello ")
                   ),
                Expression.Call(
                    null,
                    typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
                    Expression.Constant("World!")
                    ),
                Expression.Constant(42)
            );

            Console.WriteLine("The result of executing the expression tree:");
            // The following statement first creates an expression tree,
            // then compiles it, and then executes it.
            var result = Expression.Lambda<Func<int>>(blockExpr).Compile()();

            // Print out the expressions from the block expression.
            Console.WriteLine("The expressions from the block expression:");
            foreach (var expr in blockExpr.Expressions)
                Console.WriteLine(expr.ToString());

            // Print out the result of the tree execution.
            Console.WriteLine("The return value of the block expression:");
            Console.WriteLine(result);
        }
    }
}
