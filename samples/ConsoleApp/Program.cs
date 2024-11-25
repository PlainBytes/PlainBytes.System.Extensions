using System;
using ConsoleApp;

var baseTypeExamples = new BaseTypeSamples();

baseTypeExamples.StringExamples();
baseTypeExamples.IntExamples();
baseTypeExamples.LongExamples();
baseTypeExamples.ByteExamples();
baseTypeExamples.DoubleExamples();

var collectionExamples = new CollectionExamples();

collectionExamples.CollectionAccessExtensions();
collectionExamples.IterationExamples();

Console.WriteLine("Hi mom!");