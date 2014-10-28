Imports NUnit.Framework


<TestFixture>
Public Class CompilerServicesUtility_Tests

    ''' <summary>
    ''' Validate that VB compiles anonymous types with prefix "VB$Anonymous"
    ''' </summary>
    ''' <remarks></remarks>
    <Test>
    Public Sub IsAnonymousType_ValidateVBAnonTypePrefix()
        'Create an anonymous VB type
        Dim anon = New With {.Name = "Test", .ID = 1}

        Dim type = anon.GetType()
        Const prefix = "VB$Anonymous"
        Const expected = True

        Dim actual = type.Name.StartsWith(prefix)

        Assert.AreEqual(expected, actual)
    End Sub


    <Test>
    Public Sub IsAnonymousType_TestWhenTrue()
        'Create an anonymous VB type
        Dim anon = New With {.Name = "Test", .ID = 1}

        Dim type = anon.GetType()
        Const expected = True

        Dim actual = RazorEngine.Compilation.CompilerServicesUtility.IsAnonymousType(type)

        Assert.AreEqual(expected, actual)
    End Sub

    <Test>
    Public Sub IsAnonymousType_TestWhenFalse()
        'Get a named type
        Dim type = GetType(String)
        Const expected = False

        Dim actual = RazorEngine.Compilation.CompilerServicesUtility.IsAnonymousType(type)

        Assert.AreEqual(expected, actual)
    End Sub


End Class
