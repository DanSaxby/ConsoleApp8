Imports System.IO
Module Module1
    Function logname()
        Dim Day, Month, Year As String
        Day = Now.Day
        Month = Now.Month
        Year = Now.Year
        Dim Todate As String = Day + Month + Year
        logname = "C:\Users\dansax\Logs\" & Todate & ".txt"
        Return logname
    End Function
    Sub Print(Input)
        logname()
        Using sw As New System.IO.StreamWriter(logname(), True)
            sw.WriteLine(Input)
        End Using
        Console.WriteLine(Input)
    End Sub
    Function input()
        input = Console.ReadLine()
        Using sw As New System.IO.StreamWriter(logname(), True)
            sw.WriteLine(input)
        End Using
        Return input
    End Function

    Sub StringFormating()
        Dim UsersString As String
        Console.Write("Enter a string please:")
        UsersString = input()
        Print("the length of your string is:" & UsersString.Length())
        Print("the length of your string is:" & Mid(UsersString, 1, 3))
        Print("the length of your string is:" & Left(UsersString, 3))
        Print("the length of your string is:" & Right(UsersString, 3))
        Print("the length of your string is:" & Replace(UsersString, "o", "u"))
        Console.ReadLine()


    End Sub
    Sub Arrays()
        Dim Numbers(9) As Integer
        Dim i As Integer
        Dim sum, average As Integer
        'getting numbers to populate the array
        Print("please enter 10 numbers")
        Print(Numbers.Length())
        For i = 0 To (Numbers.Length() - 1)
            Print("Number " & i + 1 & ":")
            Numbers(i) = input()
        Next

        'sorts the array and then prints it
        Print("Sorted Array:")
        i = 0
        Array.Sort(Numbers)
        i = 0
        For Each i In Numbers
            Print(i)
        Next
        'Reverses the array
        Print("Reversed the array:")
        Array.Reverse(Numbers)
        i = 0
        For Each i In Numbers
            Print(i)
        Next
        'Adds each number in the list together
        Print("Sum of all the numbers:")
        i = 0
        For Each i In Numbers
            sum = i + sum
        Next
        Print(sum)
        'finds the mean of the array
        Print("The mean of the array:")
        average = sum / Numbers.Length
        Print(average)

        Console.ReadLine()

    End Sub
    Sub Binaryconvertion()
        Dim number As Integer
        Dim binary As String = ""
        Console.Write("PLease enter a dinary number to be converted: ")
        number = input()
        While number > 0
            Dim modded As Short = number Mod 2

            binary = modded.ToString() + binary
            number = number \ 2
        End While
        Print(binary)
    End Sub
    Sub Denaryconversion()
        Dim number As String
        Console.Write("PLease enter a binary number to be converted: ")
        number = input()
        number = StrReverse(number)
        Dim power As Integer = 0
        Dim result As Integer = 0
        For Each x As String In number
            result = result + (Integer.Parse(x) * (2 ^ power))
            power += 1
        Next
        Print(result)
        Console.ReadLine()
    End Sub
    Sub PasswordMaker()
        Print("How many characters do you want your password to be?")
        Dim Length As Integer = input()
        Print("Creating Password.......")
        Dim Chara As Char
        Dim Password As String = ""
        Randomize()
        For i As Integer = 0 To Length
            Chara = Chr(Int(93 * Rnd()) + 33)
            Password = Password + Chara
        Next
        Console.WriteLine(Password)
        Console.ReadLine()

    End Sub

    Sub Janky()
        Dim psi, image As New ProcessStartInfo
        Print("you have found the easter egg of your dreams press enter to proceed to paradise(Only works on dans terminal server)")
        Console.ReadLine()
        image.FileName = "easteregg.jpg"
        psi.FileName = "C:\Users\dansax\Desktop\ConsoleApp2\ConsoleApp2\ConsoleApp2\bin\Debug\netcoreapp3.1\JankyBird.exe"
        Process.Start(image)
        Threading.Thread.Sleep(1000)
        Process.Start(psi)
        'Shell("C:\Users\dansax\Desktop\ConsoleApp2\ConsoleApp2\ConsoleApp2\bin\Debug\netcoreapp3.1\JankyBird.exe")

    End Sub

    Function MenuItems()
        Dim i As Integer
        Dim lineCount = File.ReadAllLines("MenuItems.txt").Length - 1
        Dim MenuOptions(lineCount) As String
        Using sr As New StreamReader("MenuItems.txt")
            For i = 0 To lineCount
                MenuOptions(i) = sr.ReadLine()


            Next

        End Using
        Return MenuOptions
    End Function
    Sub Lettercounting()
        Console.WriteLine("What is the name of the file you would like to count the letters of")
        Dim filename As String = Console.ReadLine()
        Dim Text As String = importText(filename)
        Dim letters() As Integer = CountLetters(Text)
        CreateGraph(letters)
    End Sub
    Sub Main()

        Dim MenuOptions() As String = MenuItems()
        Do
            Dim Menuresponse As Integer = Menu(MenuOptions)
            Console.Clear()
            If Menuresponse = MenuOptions.Count + 1 Then 'the last or extra option in the menu is to exit the program
                Exit Sub
            End If
            Select Case Menuresponse
                Case 1
                    StringFormating()
                Case 2
                    Arrays()
                Case 3
                    Binaryconvertion()
                Case 4
                    Denaryconversion()
                Case 5
                    PasswordMaker()
                Case 6
                    Lettercounting()
                Case 123
                    Janky()
            End Select
        Loop
    End Sub

    Function Menu(MenuOptions As String()) As Integer
        Console.Clear()
        Print("---MENU---")
        Print("")
        For i = 0 To MenuOptions.Length - 1 'print each of the standard menu items
            Print(i + 1 & " : " & MenuOptions(i))
        Next
        Print(MenuOptions.Length + 1 & " : Exit Program") 'add an extra menu item to exit the program
        Print("")
        Return ChooseMenuOption(MenuOptions.Length + 1)
    End Function

    Function ChooseMenuOption(NumberOfOptions As Integer)
        Dim Response As Integer = -1
        Do While Response = -1 'response of -1 means that we haven't suceeded in getting a proper menu choice
            Print("Choose an item from: 1 to " & NumberOfOptions)
            Try
                Dim Inputl As Integer
                Inputl = input() 'get the users input and try to cast it to an integer
                If (Inputl > 0 And Inputl <= NumberOfOptions) Or (Inputl = 123) Then 'if this suceeds then check it's in the right range
                    Response = Inputl
                Else
                    Err.Raise(1)
                End If
            Catch ex As Exception
                Print("Please only enter an integer between 1 & " & NumberOfOptions)
            Finally
                Print("")
            End Try
        Loop
        Return Response
    End Function
End Module
