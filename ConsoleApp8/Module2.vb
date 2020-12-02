Imports System.IO
Module Module2

    Function importText(FileName As String)
        Dim text As String = ""
        Using sr As New StreamReader(FileName)
            Dim linecount As Long = File.ReadAllLines(FileName).Length
            For i = 0 To linecount
                text = text + sr.ReadLine
            Next



        End Using
        Return text
    End Function
    Function CountLetters(Text As String)
        Dim letters(127) As Integer
        Dim Ascii As Integer
        Text = Text.ToLower
        For Each i In Text
            Ascii = Asc(i)
            letters(Ascii) += 1
        Next
        Return letters
    End Function
    Sub CreateGraph(Letters() As Integer)
        Dim count As Integer = 0
        Dim character As String
        Dim bar As String
        Dim total As Double
        Dim percentage As Double
        Dim barlength As Integer
        For Each i In Letters

            total += i
        Next
        For Each i As Double In Letters
            percentage = (i / total) * 100
            percentage = percentage
            barlength = Int(percentage * 10)

            bar = ""
            character = Chr(count).ToString
            bar = StrDup(barlength, character)
            If percentage <> 0 Then
                Console.WriteLine(character + " : " + bar + "   " + percentage.ToString + "%")
            End If

            count += 1
        Next
        Console.ReadLine()
    End Sub
End Module
