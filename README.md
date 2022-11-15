# Generic Stack (in progress!)

Intermediate level task for practice generic classes and interfaces. 

Estimated time to complete the task - 1.5h.  

The task requires .NET 6 SDK installed.   

## Task Description

In this task you have to implement a class that represents a growable array based generic stack. The class must fulfill these requirements:
- The class sould be implement `IEnumerable<T>` interface.
- Fields
    - The class sould have a private field `items` to store an stack elements. The field type must be `T[]`.
    - The class sould have a private field `count` to store an count of the items in the stack. The field type must be `int`.
    - The class sould have a private field `version` to store an version of the stack object. The field type must be `int`. It using by enumerator.
    - The class sould have a private const field `DefaultCapacity` to store an default count of the inner array. The field type must be `int`. 
- Properties
    - The class sould have a public property `Count` to access the `count` field. The property sould have only the public get accessor.
- Constructors
    - The class sould have a public parameterless constructor that must initialize a class object with default values. The default value for `count` field is `0`, the default value for `items` is an array with `DefaultCapacity` length, the default value for `version` is `0`.
    - The class sould have a public constructor with `capacity` that initialize a initial capacity of the `items` array. The initial capacity
must be a non-negative number.
    - The class sould have a public constructor with `IEnumerable<T>?` parameter and fills a Stack with the contents of a particular collection. The default value for `count` field is `0`, the default value for `items` is an array with `DefaultCapacity` length, the default value for `version` is `0`.
- Instance Methods

The detailed explanations of the task are provided in the XML-comments for the methods and in test cases of unit tests.

## Task Checklist

* Build a solution in [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/ide/building-and-cleaning-projects-and-solutions-in-visual-studio?view=vs-2019). Make sure there are **no compiler errors and warnings**, fix these issues and rebuild the solution. 
* Run all unit tests with [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019) and make sure there are **no failed unit tests**. Fix your code to [make all tests GREEN](https://stackoverflow.com/questions/276813/what-is-red-green-testing). 
* Review all your changes in the codebase **before** [staging the changes and creating a commit](https://docs.microsoft.com/en-us/azure/devops/repos/git/commits?view=azure-devops&tabs=visual-studio). 
* [Stage your changes, create a commit](https://docs.microsoft.com/en-us/azure/devops/repos/git/commits?view=azure-devops&tabs=visual-studio), and publish your changes to the remote repository. 


## Additional Materials

* [Growable array based stack](https://www.geeksforgeeks.org/growable-array-based-stack/) 
* [NotImplementedException ](https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception?view=net-5.0#:~:text=The%20NotImplementedException%20exception%20indicates%20that,member%20invocation%20from%20your%20code.)
* [IEnumerator interface](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-5.0) 
* [IEnumerable<T>.GetEnumerator method ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1.getenumerator?view=net-5.0)
