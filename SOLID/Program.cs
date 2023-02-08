// See https://aka.ms/new-console-template for more information

using SOLID.InterfaceSegregationPrinciple;
using SOLID.LiskovSubstitutionPrinciple;
using SOLID.OpenClosedPrinciple;
using SOLID.SingleResponsibilityPrinciple;

Console.WriteLine("Hello, World!");
new SingleResponsibilityPrincipleDemo().Run();
new OpenClosePrincipleDemo().Run();
new LiskovSubstitutionPrincipleDemo().Run();
new InterfaceSegregationPrincipleDemo().Run();